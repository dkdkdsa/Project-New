// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SyntyStudios/URP_Prototype_Global"
{
    Properties
    {
        _BaseColor("BaseColor", Color) = (0.06228374,0.8320726,0.9411765,1)
        _Grid("Grid", 2D) = "white" {}
        _GridScale("GridScale", Float) = 5
        _Falloff("Falloff", Float) = 50
        _OverlayAmount("OverlayAmount", Range(0, 1)) = 1
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry+0" }
        LOD 200
        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode"="UniversalForward" }
            Cull Back
            ZWrite On

            HLSLPROGRAM
            #pragma prefer_hlslcc gles
            #pragma target 3.0
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile _ _SHADOWS_SOFT
            #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float3 worldPos : TEXCOORD0;
                float3 worldNormal : TEXCOORD1;
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
                OUT.worldPos = TransformObjectToWorld(IN.positionOS);
                OUT.worldNormal = TransformObjectToWorldNormal(IN.normalOS);
                return OUT;
            }

            sampler2D _Grid;
            float4 _BaseColor;
            float _GridScale;
            float _Falloff;
            float _OverlayAmount;

            float4 TriplanarSampling(float3 worldPos, float3 worldNormal)
            {
                float3 projNormal = pow(abs(worldNormal), _Falloff);
                projNormal /= (projNormal.x + projNormal.y + projNormal.z);
                float3 nsign = sign(worldNormal);

                float4 xTex = tex2D(_Grid, worldPos.zy * float2(nsign.x, 1.0) * _GridScale);
                float4 yTex = tex2D(_Grid, worldPos.xz * float2(nsign.y, 1.0) * _GridScale);
                float4 zTex = tex2D(_Grid, worldPos.xy * float2(-nsign.z, 1.0) * _GridScale);

                return xTex * projNormal.x + yTex * projNormal.y + zTex * projNormal.z;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float4 gridSample = TriplanarSampling(IN.worldPos, IN.worldNormal);
                float4 color = lerp(float4(1, 1, 1, 1), gridSample, _OverlayAmount);
                return _BaseColor * color;
            }
            ENDHLSL
        }
    }

    Fallback "Diffuse"
}

/*ASEBEGIN
Version=15900
2567;29;2510;1385;1033.358;572.502;1;True;False
Node;AmplifyShaderEditor.TexturePropertyNode;4;-367.7379,28.99442;Float;True;Property;_Grid;Grid;1;0;Create;True;0;0;False;0;None;93e718fcc411432439749387d41fa07a;False;white;Auto;Texture2D;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.RangedFloatNode;2;-300.939,312.7368;Float;False;Property;_Falloff;Falloff;3;0;Create;True;0;0;False;0;50;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3;-296.328,224.2742;Float;False;Property;_GridScale;GridScale;2;0;Create;True;0;0;False;0;5;1.36;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TriplanarNode;6;-75.25891,158.6845;Float;True;Cylindrical;World;False;Top Texture 0;_TopTexture0;white;2;None;Mid Texture 0;_MidTexture0;white;1;None;Bot Texture 0;_BotTexture0;white;2;None;Triplanar Sampler;False;9;0;SAMPLER2D;;False;5;FLOAT;1;False;1;SAMPLER2D;;False;6;FLOAT;0;False;2;SAMPLER2D;;False;7;FLOAT;0;False;8;FLOAT3;1,1,1;False;3;FLOAT;1;False;4;FLOAT;100;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;16;262,-23.5;Float;False;Constant;_White;White;5;0;Create;True;0;0;False;0;1,1,1,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;5;17.57001,360.4728;Float;False;Property;_OverlayAmount;OverlayAmount;4;0;Create;True;0;0;False;0;1;3.52;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;9;265,-214.5;Float;False;Property;_BaseColor;BaseColor;0;0;Create;True;0;0;False;0;0.06228374,0.8320726,0.9411765,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;15;514,126.5;Float;False;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;701,-52.5;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT4;0.2627451,0.7960785,0.572549,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;1;921,11;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;SyntyStudios/Prototype_Global;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;6;0;4;0
WireConnection;6;1;4;0
WireConnection;6;2;4;0
WireConnection;6;3;3;0
WireConnection;6;4;2;0
WireConnection;15;0;16;0
WireConnection;15;1;6;0
WireConnection;15;2;5;0
WireConnection;10;0;9;0
WireConnection;10;1;15;0
WireConnection;1;0;10;0
ASEEND*/
//CHKSM=7EEB3FD505F6952CCF8CFC59E7E1EF4DB75955EA