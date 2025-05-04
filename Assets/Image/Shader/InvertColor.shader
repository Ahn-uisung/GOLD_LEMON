Shader "Custom/InvertColorUI"
{
    Properties
    {
        _MainTex("Sprite Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off ZWrite Off

        Pass
        {
            Stencil {
            Ref 1
            Comp Always
            Pass Keep
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;
                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, IN.uv);
                col.rgb = 1.0 - col.rgb; // 색 반전
                col.a = tex2D(_MainTex, IN.uv).a; // 투명도 유지
                return col;
            }
            ENDCG
        }
    }
}