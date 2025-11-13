Shader "Glory Day/Alpha Mask/Standard Surface"
{
    Properties
    {
        _MainTex ("Main Texture (RGB)", 2D) = "white" {}
        _MaskTex ("Mask Texture (RGB)", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
       
        ZWrite Off
       
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask RGB
       
        Pass
        {
            SetTexture[_MainTex] { Combine texture }
            SetTexture[_MaskTex] { Combine previous, texture * previous }
        }
    }

    FallBack "Diffuse"
}