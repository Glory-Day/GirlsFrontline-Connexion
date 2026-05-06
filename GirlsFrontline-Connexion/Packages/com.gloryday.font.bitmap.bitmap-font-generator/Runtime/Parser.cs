using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GloryDay.Font.Bitmap
{
    public class Parser
    {
        private readonly Regex _expression = new Regex(@"\S+="".+?""|\S+");
        private readonly char[] _separator = { '\r', '\n' };

        private readonly List<CharacterInfo> _characterInformationCaches = new List<CharacterInfo>();
        private readonly List<RawCharacterInformation> _rawCharacterInformationCaches = new List<RawCharacterInformation>();

        public Parser(string content)
        {
            // Split the entire text from one sentence to another.
            var lines = content.Split(_separator, StringSplitOptions.RemoveEmptyEntries);

            ReadInformationSection(lines[0]);
            ReadCommonSegment(lines[1]);

            var length = TextureNames.Length;
            for (var i = 0; i < length; i++)
            {
                ReadPageSegment(lines[i + 2]);
            }

            var index = length + 2;
            length = lines.Length;
            while (index < length)
            {
                if (ReadCharacterInfoSegment(lines[index]))
                {
                    index++;
                }
            }
            CharacterInformations = _characterInformationCaches.ToArray();
            RawCharacterInformations = _rawCharacterInformationCaches.ToArray();
            _characterInformationCaches.Clear();
            _rawCharacterInformationCaches.Clear();

            // Skip empty line.
            while (index < length)
            {
                if (lines[index].Length > 0)
                {
                    break;
                }

                index++;
            }

            if (index >= length)
            {
                return;
            }

            if (ReadCountSegment(lines[index++], out var count))
            {
                KerningInformations = new KerningInformation[count];
            }

            var start = index;
            while (index < length)
            {
                if (ReadKerningInformationSegment(lines[index], index - start) == false)
                {
                    break;
                }

                index++;
            }
        }

        /// <summary>
        /// Read the section containing information.
        /// </summary>
        /// <param name="line"> The section containing information. </param>
        private void ReadInformationSection(string line)
        {
            Split(line, out var keys, out var values);

            var length = keys.Length;
            for (var i = length - 1; i >= 0; i--)
            {
                switch (keys[i])
                {
                    case Field.Information.Face:
                        FontName = values[i];
                        break;
                    case Field.Information.Size:
                        FontSize = int.Parse(values[i]);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Read the section containing texture information.
        /// </summary>
        /// <param name="line"> The section containing texture information. </param>
        private void ReadCommonSegment(string line)
        {
            Split(line, out var keys, out var values);

            var length = keys.Length;
            for (var i = length - 1; i >= 0; i--)
            {
                switch (keys[i])
                {
                    case Field.Common.LineHeight:
                        LineHeight = int.Parse(values[i]);
                        break;
                    case Field.Common.LineBaseHeight:
                        LineBaseHeight = int.Parse(values[i]);
                        break;
                    case Field.Common.TextureWidth:
                        TextureWidth = int.Parse(values[i]);
                        break;
                    case Field.Common.TextureHeight:
                        TextureHeight = int.Parse(values[i]);
                        break;
                    case Field.Common.TextureNames:
                        TextureNames = new string[int.Parse(values[i])];
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Read the section containing page information.
        /// </summary>
        /// <param name="line"> The section containing page information. </param>
        private void ReadPageSegment(string line)
        {
            var id = -1;
            string textureName = null;

            Split(line, out var keys, out var values);

            var length = keys.Length;
            for (var i = length - 1; i >= 0; i--)
            {
                switch (keys[i])
                {
                    case Field.Page.File:
                        textureName = values[i];
                        break;
                    case Field.Page.ID:
                        id = int.Parse(values[i]);
                        break;
                    default:
                        break;
                }
            }

            TextureNames[id] = textureName;
        }

        /// <summary>
        /// Read the section containing character count information.
        /// </summary>
        /// <param name="line"> The section containing character count information. </param>
        /// <param name="count"> The character count information. </param>
        private bool ReadCountSegment(string line, out int count)
        {
            Split(line, out var keys, out var values);

            count = 0;
            for (var i = keys.Length - 1; i >= 0; i--)
            {
                switch (keys[i])
                {
                    case Field.Count.Header:
                        count = int.Parse(values[i]);
                        return true;
                    default:
                        break;
                }
            }

            return false;
        }

        /// <summary>
        /// Read the section containing character information.
        /// </summary>
        /// <param name="line"> The section containing character information. </param>
        private bool ReadCharacterInfoSegment(string line)
        {
            if (line.StartsWith(Field.Character.Header) == false)
            {
                return false;
            }

            var id = 0;
            var x = 0;
            var y = 0;
            var width = 0;
            var height = 0;
            var offset = new Offset();
            var advance = 0;

            Split(line, out var keys, out var values);

            var length = keys.Length;
            for (var i = length - 1; i >= 0; i--)
            {
                switch (keys[i])
                {
                    case Field.Character.ID:
                        id = int.Parse(values[i]);
                        break;
                    case Field.Character.X:
                        x = int.Parse(values[i]);
                        break;
                    case Field.Character.Y:
                        y = int.Parse(values[i]);
                        break;
                    case Field.Character.Width:
                        width = int.Parse(values[i]);
                        break;
                    case Field.Character.Height:
                        height = int.Parse(values[i]);
                        break;
                    case Field.Character.XOffset:
                        offset.X = int.Parse(values[i]);
                        break;
                    case Field.Character.YOffset:
                        offset.Y = int.Parse(values[i]);
                        break;
                    case Field.Character.Advance:
                        advance = int.Parse(values[i]);
                        break;
                    default:
                        break;
                }
            }

            _characterInformationCaches.Add(CreateCharacterInformation(id, x, y, width, height, offset, advance));
            _rawCharacterInformationCaches.Add(new RawCharacterInformation
            {
                ID = id,
                X = x,
                Y = y,
                Width = width,
                Height = height,
                Offset = offset,
                Advance = advance,
                Page = 0
            });

            return true;
        }

        /// <summary>
        /// Read the section containing character kerning information.
        /// </summary>
        /// <param name="line"> The section containing character kerning information. </param>
        /// <param name="index"> Index number of character kerning information. </param>
        private bool ReadKerningInformationSegment(string line, int index)
        {
            if (line.StartsWith(Field.Kerning.Header) == false)
            {
                return false;
            }

            var kerningInfo = new KerningInformation();

            Split(line, out var keys, out var values);

            var length = keys.Length;
            for (var i = length - 1; i >= 0; i--)
            {
                switch (keys[i])
                {
                    case Field.Kerning.First:
                        kerningInfo.First = int.Parse(values[i]);
                        break;
                    case Field.Kerning.Second:
                        kerningInfo.Second = int.Parse(values[i]);
                        break;
                    case Field.Kerning.Amount:
                        kerningInfo.Amount = int.Parse(values[i]);
                        break;
                    default:
                        break;
                }
            }

            KerningInformations[index] = kerningInfo;

            return true;
        }

        private void Split(string line, out string[] keys, out string[] values)
        {
            var parts = _expression.Matches(line);

            var count = parts.Count;
            keys = new string[count - 1];
            values = new string[count - 1];
            for (var i = count - 2; i >= 0; i--)
            {
                var part = parts[i + 1].Value;
                var index = part.IndexOf('=');
                keys[i] = part.Substring(0, index);
                values[i] = part.Substring(index + 1).Trim('"');
            }
        }

        private CharacterInfo CreateCharacterInformation(int id, int x, int y, int width, int height, Offset offset, int advance, int page = 0)
        {
            var uv = new Rect
            {
                x = ((float)x / TextureWidth) + page,
                y = (float)y / TextureHeight,
                width = (float)width / TextureWidth,
                height = (float)height / TextureHeight
            };
            uv.y = 1f - uv.y - uv.height;

            var vertex = new Rect { x = offset.X };

#if UNITY_5_0 || UNITY_5_1 || UNITY_5_2

            // unity 5.0 can not support baseline for 
            vert.y = yo;
#else

            vertex.y = offset.Y - LineBaseHeight;

#endif

            vertex.width = width;
            vertex.height = height;
            vertex.y = -vertex.y;
            vertex.height = -vertex.height;

            var characterInfo = new CharacterInfo { index = id };

#if UNITY_5_3_OR_NEWER || UNITY_5_3 || UNITY_5_2

            characterInfo.uvBottomLeft = new Vector2(uv.xMin, uv.yMin);
            characterInfo.uvBottomRight = new Vector2(uv.xMax, uv.yMin);
            characterInfo.uvTopLeft = new Vector2(uv.xMin, uv.yMax);
            characterInfo.uvTopRight = new Vector2(uv.xMax, uv.yMax);

            characterInfo.minX = (int)vertex.xMin;
            characterInfo.maxX = (int)vertex.xMax;
            characterInfo.minY = (int)vertex.yMax;
            characterInfo.maxY = (int)vertex.yMin;

            characterInfo.bearing = (int)vertex.x;
            characterInfo.advance = advance;

#else

#pragma warning disable 618

            characterInfo.uv = uv;
            characterInfo.vert = vertex;
            characterInfo.width = advance;

#pragma warning restore 618

#endif

            return characterInfo;
        }

        public string FontName { get; private set; }

        public int FontSize { get; private set; }

        public int LineHeight { get; private set; }

        public int LineBaseHeight { get; private set; }

        public int TextureWidth { get; private set; }

        public int TextureHeight { get; private set; }

        public string[] TextureNames { get; private set; }

        public CharacterInfo[] CharacterInformations { get; private set; }

        public RawCharacterInformation[] RawCharacterInformations { get; private set; }

        public KerningInformation[] KerningInformations { get; private set; }
    }
}