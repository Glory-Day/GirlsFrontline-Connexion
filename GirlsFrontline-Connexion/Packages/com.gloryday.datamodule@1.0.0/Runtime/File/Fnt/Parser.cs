using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GloryDay.Data.File.Fnt
{
    public class Parser
    {
        private readonly Regex _regularExpression = new Regex(@"\S+="".+?""|\S+");
        private readonly char[] _separator = { '\r', '\n' };

        private readonly List<CharacterInfo> _characterInfoCaches = new List<CharacterInfo>();
        private readonly List<RawCharacterInfo> _rawCharacterInfoCaches = new List<RawCharacterInfo>();
        
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
            CharacterInfos = _characterInfoCaches.ToArray();
            RawCharacterInfos = _rawCharacterInfoCaches.ToArray();
            _characterInfoCaches.Clear();
            _rawCharacterInfoCaches.Clear();

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
                KerningInfos = new KerningInfo[count];
            }
                
            var start = index;
            while (index < length)
            {
                if (ReadKerningInfoSegment(lines[index], index - start) == false)
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
                    case FieldName.Information.Face:
                        FontName = values[i];
                        break;
                    case FieldName.Information.Size:
                        FontSize = int.Parse(values[i]);
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
                    case FieldName.Common.LineHeight:
                        LineHeight = int.Parse(values[i]);
                        break;
                    case FieldName.Common.LineBaseHeight:
                        LineBaseHeight = int.Parse(values[i]);
                        break;
                    case FieldName.Common.TextureWidth:
                        TextureWidth = int.Parse(values[i]);
                        break;
                    case FieldName.Common.TextureHeight:
                        TextureHeight = int.Parse(values[i]);
                        break;
                    case FieldName.Common.TextureNames:
                        TextureNames = new string[int.Parse(values[i])];
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
                    case FieldName.Page.File: 
                        textureName = values[i]; 
                        break;
                    case FieldName.Page.ID: 
                        id = int.Parse(values[i]); 
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
                    case FieldName.Count.Header:
                        count = int.Parse(values[i]);
                        return true;
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
            if (line.StartsWith(FieldName.Character.Header) == false)
            {
                return false;
            }

            var id = 0;
            int x = 0, y = 0, width = 0,height = 0;
            int xOffset = 0, yOffset = 0;
            var advance = 0;
            
            Split(line, out var keys, out var values);

            var length = keys.Length;
            for (var i = length - 1; i >= 0; i--)
            {
                switch (keys[i])
                {
                    case FieldName.Character.ID: 
                        id = int.Parse(values[i]);
                        break;
                    case FieldName.Character.X: 
                        x = int.Parse(values[i]); 
                        break;
                    case FieldName.Character.Y: 
                        y = int.Parse(values[i]); 
                        break;
                    case FieldName.Character.Width: 
                        width = int.Parse(values[i]); 
                        break;
                    case FieldName.Character.Height: 
                        height = int.Parse(values[i]); 
                        break;
                    case FieldName.Character.XOffset: 
                        xOffset = int.Parse(values[i]); 
                        break;
                    case FieldName.Character.YOffset: 
                        yOffset = int.Parse(values[i]); 
                        break;
                    case FieldName.Character.Advance: 
                        advance = int.Parse(values[i]); 
                        break;
                }
            }
            
            _characterInfoCaches.Add(CreateCharacterInfo(id, x, y, width, height, xOffset, yOffset, advance));
            _rawCharacterInfoCaches.Add(new RawCharacterInfo
                                        {
                                            ID = id,
                                            X = x, Y = y, Width = width, Height = height,
                                            XOffset = xOffset, YOffset = yOffset,
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
        private bool ReadKerningInfoSegment(string line, int index)
        {
            if (line.StartsWith(FieldName.Kerning.Header) == false)
            {
                return false;
            }
            
            var kerningInfo = new KerningInfo();

            Split(line, out var keys, out var values);

            var length = keys.Length;
            for (var i = length - 1; i >= 0; i--)
            {
                switch (keys[i])
                {
                    case FieldName.Kerning.First: 
                        kerningInfo.First = int.Parse(values[i]); 
                        break;
                    case FieldName.Kerning.Second: 
                        kerningInfo.Second = int.Parse(values[i]);
                        break;
                    case FieldName.Kerning.Amount: 
                        kerningInfo.Amount = int.Parse(values[i]);
                        break;
                }
            }
            
            KerningInfos[index] = kerningInfo;
            
            return true;
        }

        private void Split(string line, out string[] keys, out string[] values)
        {
            var parts = _regularExpression.Matches(line);
            
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
        
        private CharacterInfo CreateCharacterInfo(int id,
                                                  int x, int y, int width, int height,
                                                  int xOffset, int yOffset,
                                                  int advance,
                                                  int page = 0)
        {
            var uv = new Rect
                     {
                         x = (float)x / TextureWidth + page,
                         y = (float)y / TextureHeight,
                         width = (float)width / TextureWidth,
                         height = (float)height / TextureHeight
                     };
            uv.y = 1f - uv.y - uv.height;

            var vertex = new Rect { x = xOffset };

#if UNITY_5_0 || UNITY_5_1 || UNITY_5_2

            // unity 5.0 can not support baseline for 
            vert.y = yo;
#else

            vertex.y = yOffset - LineBaseHeight;

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
        
        public CharacterInfo[] CharacterInfos { get; private set; }

        public RawCharacterInfo[] RawCharacterInfos { get; private set; }
        
        public KerningInfo[] KerningInfos { get; private set; }
    }
}