#if UNITY_EDITOR

using GloryDay.Data.File.Fnt;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore;

namespace GloryDay.Data
{
    public class BitmapFontConverter : EditorWindow
    {
        private Texture2D _texture2D;
        private TextAsset _source;
        private TMP_FontAsset _destination;
        
        private static readonly int MainTexture = Shader.PropertyToID("_MainTex");

        [MenuItem("Window/Bitmap Font Converter")]
        public static void ShowWindow()
        {
            GetWindow(typeof(BitmapFontConverter), false, "Bitmap Font Converter");
        }

        private void PatchGlyph(ref Glyph glyph, RawCharacterInfo characterInfo, int textureHeight, int textureWidth)
        {
            // Calculate scale width and height.
            var scaleWidth = textureHeight / textureWidth > 1 ? textureHeight / textureWidth : 1;
            var scaleHeight = textureWidth / textureHeight > 1 ? textureWidth / textureHeight : 1;
            
            // Set glyph rect property.
            glyph.glyphRect = new GlyphRect(
                characterInfo.X * scaleWidth,
                (textureHeight - characterInfo.Y - characterInfo.Height) * scaleHeight,
                characterInfo.Width * scaleWidth,
                characterInfo.Height * scaleHeight
            );
            
            // Set glyph metrics property.
            glyph.metrics = new GlyphMetrics(
                characterInfo.Width,
                characterInfo.Height,
                characterInfo.XOffset,
                -characterInfo.YOffset,
                characterInfo.Advance
            );
        }

        private void UpdateFont(TMP_FontAsset fontFile)
        {
            var fontText = _source.text;
            var parser = new Parser(fontText);

            for (var i = 0; i < fontFile.characterTable.Count; i++)
            {
                var characterTable = fontFile.characterTable[i];
                
                var unicode = characterTable.unicode;
                var glyphIndex = characterTable.glyphIndex;
                for (var j = 0; j < parser.CharacterInfos.Length; j++)
                {
                    if (unicode != parser.CharacterInfos[j].index)
                    {
                        continue;
                    }
                    
                    var glyph = fontFile.glyphLookupTable[glyphIndex];
                    PatchGlyph(ref glyph, parser.RawCharacterInfos[j], parser.TextureHeight, parser.TextureWidth);
                    fontFile.glyphLookupTable[glyphIndex] = glyph;
                    
                    break;
                }
            }

            var faceInfo = fontFile.faceInfo;
            faceInfo.baseline = parser.LineBaseHeight;
            faceInfo.lineHeight = parser.LineHeight;
            faceInfo.ascentLine = parser.LineHeight;
            faceInfo.pointSize = parser.FontSize;

            var fontType = typeof(TMP_FontAsset);
            var faceInfoProperty = fontType.GetProperty("faceInfo");
            faceInfoProperty?.SetValue(fontFile, faceInfo);

            fontFile.material.SetTexture(MainTexture, _texture2D);
            fontFile.atlasTextures[0] = _texture2D;
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            _texture2D = EditorGUILayout.ObjectField(
                "Font Texture", _texture2D, typeof(Texture2D), false) as Texture2D;
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            _source = EditorGUILayout.ObjectField(
                "Source Font File (.fnt)", _source, typeof(TextAsset), false) as TextAsset;
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            _destination = EditorGUILayout.ObjectField(
                "Destination Font File", _destination, typeof(TMP_FontAsset), false) as TMP_FontAsset;
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Convert"))
            {
                UpdateFont(_destination);
            }
        }
    }
}

#endif