Shader "Glory Day/Particles/Bitmap Font"
{
    Properties
    {
        _MainTexture ("Texture", 2D) = "white" {}
        _Column ("Columns Count", Int) = 4
        _Row ("Rows Count", Int) = 4
    }
    SubShader
    {            
        Tags { "RenderType"="Opaque" "PreviewType"="Plane" "Queue"="Transparent+1"}
        
        LOD 100
        
        ZWrite Off
        
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                fixed4 color : COLOR;
                float4 uv : TEXCOORD0;
                float4 custom_data_01 : TEXCOORD1;
                float4 custom_data_02 : TEXCOORD2;
            };           

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float4 uv : TEXCOORD0;
                float4 custom_data_01 : TEXCOORD1;
                float4 custom_data_02 : TEXCOORD2;
            };
            
            uniform sampler2D _MainTexture;
            uniform uint _Column;
            uniform uint _Row;
            
            v2f vert (appdata v)
            {
                v2f o;

                const float length = ceil(fmod(v.custom_data_02.w, 100));

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv.xy = v.uv.xy * fixed2(length / _Column, 1.0 / _Row);
                o.uv.zw = v.uv.zw;
                o.color = v.color;                
                o.custom_data_01 = floor(v.custom_data_01);
                o.custom_data_02 = floor(v.custom_data_02);
                
                return o;
            }
            
            fixed4 frag (v2f v) : SV_Target
            {
                fixed2 uv = v.uv.xy;

                /// The length of the characters.
                const uint length = floor(uv.x * _Column);
                
                /// The index number of coordinates stored in a given custom data.
                uint index = length / 3;

                /// The data in which the coordinates of the characters are stored.
                uint coordinates = index < 4 ? v.custom_data_01[index] : v.custom_data_02[index - 4];

                uint x = 0;
                uint y = 0;

                // The coordinates are obtained by calculating the digits of the number.
                for (int i = 0; i < 3; ++i)
                {
                    if (index > 3 & i == 3)
                    {
                        break;
                    }
                    
                    /// A digit to obtain a coordinate from a number in which the coordinates are stored.
                    uint digit = ceil(pow(10, 5 - i * 2));
                    x = coordinates / digit;
                    coordinates -= x * digit;
                    
                    digit = ceil(pow(10, 4 - i * 2));
                    y = coordinates / digit;
                    coordinates -= floor(y * digit);

                    if (index * 3 + i == length)
                    {
                        i = 3;
                    }
                }                

                const float width = 1.0 / _Column;
                const float height = 1.0 / _Row;
                uv.x += x * width - length * height;
                uv.y += y * height;
                
                return tex2D(_MainTexture, uv.xy) * v.color;
            }
            
            ENDCG
        }
    }
}