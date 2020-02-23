Shader "Fade" {

    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }

        Pass
        {
            ZWrite On
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float4 uv0 : TEXCOORD0;
                float4 uv1 : TEXCOORD1;
                fixed4 color : COLOR;
            };

            struct v2f {
                float4 uv0 : TEXCOORD0;
                float4 uv1 : TEXCOORD1;
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
            };

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv0 = v.uv0;
                o.uv1 = v.uv1;
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = i.color;
                if (false) {
                    float factx = min((1 - abs(i.uv0.x)) * i.uv0.z, 1);
                    float facty = min((1 - abs(i.uv0.y)) * i.uv0.w, 1);
                    col.a *= min(factx, facty);
                } else {
                    float factx = (i.uv0.x+1)*0.5;
                    float facty = (i.uv0.y-1)*0.5;
                    // *0.75 only for the big triangle
                    float fact = 1-sqrt(factx*factx + facty*facty);
                    fact = min(fact * i.uv0.w, 1);
                    col.a *= fact;
                }
                return col;
            }
            ENDCG
        }
    }
}