Shader "Unlit/Gradient"
{
    Properties
    {
        _ColorA("Color A", Color) = (1, 1, 1, 1)
        _ColorB("Color B", Color) = (1, 1, 1, 1)
        _ColorC("Color C", Color) = (1, 1, 1, 1)
        _ColorD("Color D", Color) = (1, 1, 1, 1)
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // make fog work


            #include "UnityCG.cginc"

                float4 _ColorA;
                float4 _ColorB;
                float4 _ColorC;
                float4 _ColorD;

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float4 uv0 : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
                //UNITY_FOG_COORDS(1)
            };

            //sampler2D _MainTex;
            //float4 _MainTex_ST;

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normals);
                o.uv = v.uv0;
//                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(Interpolators i) : SV_Target
            {
                // sample the texture
  //              fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
   //             UNITY_APPLY_FOG(i.fogCoord, col);
                float4 outputColor;
                if(i.uv.y <= 0.33f)
                    outputColor = lerp(_ColorA, _ColorB, i.uv.y * 3);
                else if (i.uv.y <= 0.66f)
                    outputColor = lerp(_ColorB, _ColorC, (i.uv.y - 0.33f) * 3);
                else
                    outputColor = lerp(_ColorC, _ColorD, (i.uv.y - 0.66f) * 3);
                return outputColor;
            }
            ENDCG
        }
    }
}
