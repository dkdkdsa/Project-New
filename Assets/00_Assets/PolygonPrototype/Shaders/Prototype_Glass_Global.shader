// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "SyntyStudios/Prototype_Glass_URP"
{
    Properties
    {
        _BaseColor("BaseColor", Color) = (0.06228374,0.8320726,0.9411765,0)
        _Grid("Grid", 2D) = "white" {}
        _GridScale("GridScale", Float) = 5
        _Falloff("Falloff", Float) = 50
        _Opacity("Opacity", Color) = (0.5661765,0.5661765,0.5661765,0)
        _OverlayAmount("OverlayAmount", Range(0 , 1)) = 1
        _Smoothness("Smoothness", Range(0 , 1)) = 1
        _Specular("Specular", Range(0 , 1)) = 0.1
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }
            Blend SrcAlpha OneMinusSrcAlpha // 알파 블렌딩 설정 추가
            ZWrite Off // 투명한 오브젝트에서 ZWrite Off 설정
            Cull Back

            HLSLPROGRAM
            #pragma prefer_hlslcc gles
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float3 normalWS : TEXCOORD1;
                float2 uv : TEXCOORD0;
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
                OUT.normalWS = TransformObjectToWorldNormal(IN.normalOS);
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 _BaseColor;
            half4 _Opacity;
            sampler2D _Grid;
            float _GridScale;
            float _Falloff;
            float _OverlayAmount;
            float _Smoothness;
            float _Specular;

            half4 TriplanarSample(float3 worldPos, float3 worldNormal)
            {
                float3 projNormal = pow(abs(worldNormal), _Falloff);
                projNormal /= (projNormal.x + projNormal.y + projNormal.z);
                float3 nsign = sign(worldNormal);

                half4 xNorm = tex2D(_Grid, worldPos.zy * _GridScale * float2(nsign.x, 1.0));
                half4 yNorm = tex2D(_Grid, worldPos.xz * _GridScale * float2(nsign.y, 1.0));
                half4 zNorm = tex2D(_Grid, worldPos.xy * _GridScale * float2(-nsign.z, 1.0));

                return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 triplanar = TriplanarSample(IN.normalWS, normalize(IN.normalWS));
                half4 overlayColor = lerp(_Opacity, triplanar, _OverlayAmount);

                // Color output
                half4 color = _BaseColor;
                color.rgb *= overlayColor.rgb;

                // Alpha 값을 투명도로 반영
                color.a = overlayColor.a;

                return color;
            }

            ENDHLSL
        }
    }
    Fallback Off
}


/*ASEBEGIN
Version=15900
2567;29;2510;1385;1057.618;574.5319;1.005;True;False
Node;AmplifyShaderEditor.RangedFloatNode;2;-365.939,248.7368;Float;False;Property;_Falloff;Falloff;3;0;Create;True;0;0;False;0;50;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3;-370.328,165.2742;Float;False;Property;_GridScale;GridScale;2;0;Create;True;0;0;False;0;5;1.36;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;4;-444.7379,-57.00558;Float;True;Property;_Grid;Grid;1;0;Create;True;0;0;False;0;None;93e718fcc411432439749387d41fa07a;False;white;Auto;Texture2D;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.TriplanarNode;6;-91.2589,129.6845;Float;True;Cylindrical;World;False;Top Texture 0;_TopTexture0;white;2;None;Mid Texture 0;_MidTexture0;white;1;None;Bot Texture 0;_BotTexture0;white;2;None;Triplanar Sampler;False;9;0;SAMPLER2D;;False;5;FLOAT;1;False;1;SAMPLER2D;;False;6;FLOAT;0;False;2;SAMPLER2D;;False;7;FLOAT;0;False;8;FLOAT3;1,1,1;False;3;FLOAT;1;False;4;FLOAT;100;False;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;5;15.27,378.4728;Float;False;Property;_OverlayAmount;OverlayAmount;5;0;Create;True;0;0;False;0;1;3.52;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;16;267.61,-43.59;Float;False;Property;_Opacity;Opacity;4;0;Create;True;0;0;False;0;0.5661765,0.5661765,0.5661765,0;0.5661765,0.5661765,0.5661765,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;22;472.9952,426.4481;Float;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.BlendOpsNode;24;718.2164,420.4175;Float;False;Screen;True;2;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ColorNode;9;317.2801,621.8003;Float;False;Property;_BaseColor;BaseColor;0;0;Create;True;0;0;False;0;0.06228374,0.8320726,0.9411765,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;15;557.0811,116.89;Float;False;3;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.OneMinusNode;19;800.3583,148.8228;Float;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;21;694.642,-161.502;Float;False;Property;_Smoothness;Smoothness;7;0;Create;True;0;0;False;0;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;20;690.642,-246.502;Float;False;Property;_Specular;Specular;8;0;Create;True;0;0;False;0;0.1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;25;935.2972,552.073;Float;False;2;2;0;FLOAT4;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;18;1096,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;StandardSpecular;SyntyStudios/Prototype_Glass_Global;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;2;5;False;-1;10;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;6;0;4;0
WireConnection;6;1;4;0
WireConnection;6;2;4;0
WireConnection;6;3;3;0
WireConnection;6;4;2;0
WireConnection;22;0;6;0
WireConnection;24;0;22;0
WireConnection;15;0;16;0
WireConnection;15;1;6;0
WireConnection;15;2;5;0
WireConnection;19;0;15;0
WireConnection;25;0;24;0
WireConnection;25;1;9;0
WireConnection;18;0;25;0
WireConnection;18;3;20;0
WireConnection;18;4;21;0
WireConnection;18;9;19;0
ASEEND*/
//CHKSM=09336F6E99C6C51919FCEB950010D5DA7F958A95