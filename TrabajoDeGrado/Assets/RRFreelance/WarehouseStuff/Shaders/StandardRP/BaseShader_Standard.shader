// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "RRF/Standard/BaseShader_Standard"
{
	Properties
	{
		_BaseTint("BaseTint", Color) = (1,1,1,0)
		_Albedo("Albedo", 2D) = "white" {}
		_ORM("ORM(Ao,Roughness,Metal)", 2D) = "white" {}
		[Toggle(_TOGGLEROUGHNESSTOGLOSS_ON)] _ToggleRoughnessToGloss("ToggleRoughnessToGloss", Float) = 1
		_GlossAdjust("GlossAdjust", Range( -1 , 1)) = 0
		_MetalnessAdjust("MetalnessAdjust", Range( -1 , 1)) = 0
		_AO_Power("AO_Power", Range( 0 , 3)) = 1
		_AO_IntoAlbedo("AO_IntoAlbedo", Range( 0 , 1)) = 0.25
		_Emissive("Emissive", Range( 0 , 1)) = 0
		_NormalMap("NormalMap", 2D) = "bump" {}
		_NormalMap_Power("NormalMap_Power", Range( 0 , 3)) = 1
		[Toggle(_FLIPGREEN_ON)] _FlipGreen("FlipGreen?", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma shader_feature _FLIPGREEN_ON
		#pragma shader_feature _TOGGLEROUGHNESSTOGLOSS_ON
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _NormalMap;
		uniform float4 _NormalMap_ST;
		uniform float _NormalMap_Power;
		uniform float4 _BaseTint;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform sampler2D _ORM;
		uniform float4 _ORM_ST;
		uniform float _AO_Power;
		uniform float _AO_IntoAlbedo;
		uniform float _Emissive;
		uniform float _MetalnessAdjust;
		uniform float _GlossAdjust;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_NormalMap = i.uv_texcoord * _NormalMap_ST.xy + _NormalMap_ST.zw;
			float3 tex2DNode33 = UnpackNormal( tex2D( _NormalMap, uv_NormalMap ) );
			float3 break42 = tex2DNode33;
			#ifdef _FLIPGREEN_ON
				float staticSwitch44 = ( 1.0 - tex2DNode33.g );
			#else
				float staticSwitch44 = tex2DNode33.g;
			#endif
			float4 appendResult43 = (float4(break42.x , staticSwitch44 , break42.z , 0.0));
			float4 lerpResult34 = lerp( float4( 0,0,1,0 ) , appendResult43 , _NormalMap_Power);
			float4 out_normal37 = lerpResult34;
			o.Normal = out_normal37.xyz;
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 temp_output_46_0 = ( _BaseTint * tex2D( _Albedo, uv_Albedo ) );
			float2 uv_ORM = i.uv_texcoord * _ORM_ST.xy + _ORM_ST.zw;
			float4 tex2DNode2 = tex2D( _ORM, uv_ORM );
			float3 temp_cast_1 = (tex2DNode2.r).xxx;
			float temp_output_2_0_g1 = _AO_Power;
			float temp_output_3_0_g1 = ( 1.0 - temp_output_2_0_g1 );
			float3 appendResult7_g1 = (float3(temp_output_3_0_g1 , temp_output_3_0_g1 , temp_output_3_0_g1));
			float3 out_ao11 = saturate( ( ( temp_cast_1 * temp_output_2_0_g1 ) + appendResult7_g1 ) );
			float4 lerpResult18 = lerp( temp_output_46_0 , ( float4( out_ao11 , 0.0 ) * temp_output_46_0 ) , _AO_IntoAlbedo);
			float4 out_albedo21 = lerpResult18;
			float4 temp_output_22_0 = out_albedo21;
			o.Albedo = temp_output_22_0.rgb;
			o.Emission = ( out_albedo21 * _Emissive ).rgb;
			float out_metal10 = saturate( ( tex2DNode2.b + _MetalnessAdjust ) );
			o.Metallic = out_metal10;
			#ifdef _TOGGLEROUGHNESSTOGLOSS_ON
				float staticSwitch3 = ( 1.0 - tex2DNode2.g );
			#else
				float staticSwitch3 = tex2DNode2.g;
			#endif
			float out_gloss12 = saturate( ( staticSwitch3 + _GlossAdjust ) );
			o.Smoothness = out_gloss12;
			o.Occlusion = out_ao11.x;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=18800
623.3334;610.6667;1195;776;2190.492;619.1047;1.071511;True;False
Node;AmplifyShaderEditor.CommentaryNode;31;-1763.908,-494.3143;Inherit;False;1303.667;490;AO Roughness metalness;14;6;2;7;4;11;8;14;3;13;9;16;15;12;10;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;2;-1713.908,-444.3143;Inherit;True;Property;_ORM;ORM(Ao,Roughness,Metal);2;0;Create;False;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;6;-1711.687,-217.6164;Inherit;False;Property;_AO_Power;AO_Power;6;0;Create;True;0;0;0;False;0;False;1;0;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;47;-1405.713,-249.4256;Inherit;False;Lerp White To;-1;;1;047d7c189c36a62438973bad9d37b1c2;0;2;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode;32;-1750.65,-894.3008;Inherit;False;961.5963;357.3606;Albedo;6;17;1;20;19;18;21;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SaturateNode;7;-1213.908,-223.3143;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode;38;-1768.748,59.56625;Inherit;False;1311.607;353.3845;NormalMap;8;37;34;33;36;41;42;44;43;;1,1,1,1;0;0
Node;AmplifyShaderEditor.ColorNode;45;-1623.713,-1042.556;Inherit;False;Property;_BaseTint;BaseTint;0;0;Create;True;0;0;0;False;0;False;1,1,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-1700.65,-770.6627;Inherit;True;Property;_Albedo;Albedo;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;33;-1718.748,128.6277;Inherit;True;Property;_NormalMap;NormalMap;9;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;11;-1068.908,-226.3143;Inherit;False;out_ao;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;46;-1366.713,-996.5562;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;17;-1591.463,-844.3008;Inherit;False;11;out_ao;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode;4;-1311.908,-336.3143;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;41;-1426.845,318.1866;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;20;-1378.003,-651.9402;Inherit;False;Property;_AO_IntoAlbedo;AO_IntoAlbedo;7;0;Create;True;0;0;0;False;0;False;0.25;0.25;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;42;-1416.845,134.1792;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.RangedFloatNode;14;-1120.908,-305.3143;Inherit;False;Property;_GlossAdjust;GlossAdjust;4;0;Create;True;0;0;0;False;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-1632.908,-126.3143;Inherit;False;Property;_MetalnessAdjust;MetalnessAdjust;5;0;Create;True;0;0;0;False;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;3;-1311.908,-430.3143;Inherit;False;Property;_ToggleRoughnessToGloss;ToggleRoughnessToGloss;3;0;Create;True;0;0;0;True;0;False;0;1;1;True;;Toggle;2;Key0;Key1;Create;False;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;44;-1283.84,300.1862;Inherit;False;Property;_FlipGreen;FlipGreen?;11;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;False;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-1346.003,-843.9401;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DynamicAppendNode;43;-1189.836,133.1791;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleAddOpNode;13;-964.9083,-420.3143;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;18;-1198.003,-764.9404;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;9;-1337.908,-137.3143;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;36;-1024.08,237.6891;Inherit;False;Property;_NormalMap_Power;NormalMap_Power;10;0;Create;True;0;0;0;False;0;False;1;0;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;21;-1037.72,-770.1394;Inherit;False;out_albedo;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;16;-845.9083,-408.3143;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;15;-1203.908,-142.3143;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;34;-938.0799,117.6891;Inherit;False;3;0;FLOAT4;0,0,1,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;27;303.1044,-192.3905;Inherit;False;Property;_Emissive;Emissive;8;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;10;-1065.908,-145.3143;Inherit;False;out_metal;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;22;382.3302,-335.7756;Inherit;False;21;out_albedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;12;-708.9083,-413.3143;Inherit;False;out_gloss;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;37;-725.553,114.659;Inherit;False;out_normal;-1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;40;591.1621,-239.8124;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;23;389.5602,29.82246;Inherit;False;11;out_ao;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;24;385.606,-44.28076;Inherit;False;12;out_gloss;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;25;381.4683,-121.3381;Inherit;False;10;out_metal;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;39;381.5867,-260.3188;Inherit;False;37;out_normal;1;0;OBJECT;;False;1;FLOAT4;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;785.9964,-283.8502;Float;False;True;-1;2;;0;0;Standard;RRF/Standard/BaseShader_Standard;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;47;1;2;1
WireConnection;47;2;6;0
WireConnection;7;0;47;0
WireConnection;11;0;7;0
WireConnection;46;0;45;0
WireConnection;46;1;1;0
WireConnection;4;0;2;2
WireConnection;41;0;33;2
WireConnection;42;0;33;0
WireConnection;3;1;2;2
WireConnection;3;0;4;0
WireConnection;44;1;33;2
WireConnection;44;0;41;0
WireConnection;19;0;17;0
WireConnection;19;1;46;0
WireConnection;43;0;42;0
WireConnection;43;1;44;0
WireConnection;43;2;42;2
WireConnection;13;0;3;0
WireConnection;13;1;14;0
WireConnection;18;0;46;0
WireConnection;18;1;19;0
WireConnection;18;2;20;0
WireConnection;9;0;2;3
WireConnection;9;1;8;0
WireConnection;21;0;18;0
WireConnection;16;0;13;0
WireConnection;15;0;9;0
WireConnection;34;1;43;0
WireConnection;34;2;36;0
WireConnection;10;0;15;0
WireConnection;12;0;16;0
WireConnection;37;0;34;0
WireConnection;40;0;22;0
WireConnection;40;1;27;0
WireConnection;0;0;22;0
WireConnection;0;1;39;0
WireConnection;0;2;40;0
WireConnection;0;3;25;0
WireConnection;0;4;24;0
WireConnection;0;5;23;0
ASEEND*/
//CHKSM=B5B6C522CE6F251A21AE7174E3DBAC80322DDB02