Shader "Unlit/outlineUIIMAGE"
{
    Properties
    {
        [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (1,0,0,1)
        _OutlineThickness ("Outline Thickness", Range(0, 10)) = 1
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15
    }

    SubShader
    {
        // Add the required UI blending
        Tags { "RenderType"="Transparent" "Queue"="Transparent" "IgnoreProjector"="True" "CanUseSpriteAtlas"="True" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZTest [unity_GUIZTestMode] // Ensures correct rendering with UI elements
        ZWrite Off

        Pass
        {
            Name "UIOutline"
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "UnityUI.cginc" // Includes built-in UI macros and variables

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 uv       : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                float4 color    : COLOR;
                float2 uv       : TEXCOORD0;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _OutlineColor;
            float _OutlineThickness;

            v2f vert (appdata_t v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = v.color * _Color;
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = fixed4(0,0,0,0);
                float2 uv = i.uv;
                float t = _OutlineThickness * 0.01; // Adjust thickness as needed for screen size

                // Sample neighbors (simplified, a loop is better but this is for demonstration)
                float alphaSum = 0;
                alphaSum += tex2D(_MainTex, uv + float2(t, t)).a;
                alphaSum += tex2D(_MainTex, uv + float2(-t, -t)).a;
                alphaSum += tex2D(_MainTex, uv + float2(-t, t)).a;
                alphaSum += tex2D(_MainTex, uv + float2(t, -t)).a;
                alphaSum += tex2D(_MainTex, uv + float2(t, 0)).a;
                alphaSum += tex2D(_MainTex, uv + float2(-t, 0)).a;
                alphaSum += tex2D(_MainTex, uv + float2(0, t)).a;
                alphaSum += tex2D(_MainTex, uv + float2(0, -t)).a;

                fixed4 mainColor = tex2D(_MainTex, uv) * i.color;
                
                // If any neighbor has alpha, draw the outline
                if (alphaSum > 0.0) {
                    col = _OutlineColor;
                }

                // Blend with the main color, prioritizing the main image if present
                col = lerp(col, mainColor, mainColor.a);
                
                return col;
            }
            ENDCG
        }
    }
}
