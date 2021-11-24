Shader "NickCharacters" {
	Properties {
		[Enum(Front, 2, Back, 1, Both, 0)] _Cull ("Render Face", Float) = 2
		[TCP2ToggleNoKeyword] _ZWrite ("Depth Write", Float) = 1
		[HideInInspector] _RenderingMode ("rendering mode", Float) = 0
		[HideInInspector] _SrcBlend ("blending source", Float) = 1
		[HideInInspector] _DstBlend ("blending destination", Float) = 0
		[TCP2Separator] [TCP2HeaderHelp(Base)] _Color ("Color", Vector) = (1,1,1,1)
		[TCP2ColorNoAlpha] _HColor ("Highlight Color", Vector) = (0.75,0.75,0.75,1)
		[TCP2ColorNoAlpha] _SColor ("Shadow Color", Vector) = (0.2,0.2,0.2,1)
		_MainTex ("Albedo", 2D) = "white" {}
		[NoScaleOffset] _Albedo ("AO texture", 2D) = "white" {}
		_Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.5
		[TCP2Separator] [TCP2Header(Ramp Shading)] _RampThreshold ("Threshold", Range(0.01, 1)) = 0.5
		_RampSmoothing ("Smoothing", Range(0.001, 1)) = 0.5
		[TCP2Separator] [TCP2HeaderHelp(Specular)] [Toggle(TCP2_SPECULAR)] _UseSpecular ("Enable Specular", Float) = 0
		[TCP2ColorNoAlpha] _SpecularColor ("Specular Color", Vector) = (0.5,0.5,0.5,1)
		[NoScaleOffset] _SpecularColor1 ("Specular Color Texture", 2D) = "white" {}
		_SpecularRoughnessPBR ("Roughness", Range(0, 1)) = 0.5
		[TCP2Separator] [TCP2HeaderHelp(Emission)] [TCP2ColorNoAlpha] [HDR] _Emission ("Emission Color", Vector) = (0,0,0,1)
		[NoScaleOffset] _Emission1 ("Emission Texture", 2D) = "white" {}
		[TCP2Separator] [TCP2HeaderHelp(Rim Lighting)] [Toggle(TCP2_RIM_LIGHTING)] _UseRim ("Enable Rim Lighting", Float) = 0
		[TCP2ColorNoAlpha] [HDR] _RimColor ("Rim Color", Vector) = (0.8,0.8,0.8,0.5)
		_RimMin ("Rim Min", Range(0, 2)) = 0.5
		_RimMax ("Rim Max", Range(0, 2)) = 1
		_RimDir ("Rim Direction", Vector) = (0,0,1,1)
		[TCP2Separator] [TCP2HeaderHelp(Reflections)] [Toggle(TCP2_REFLECTIONS)] _UseReflections ("Enable Reflections", Float) = 0
		[TCP2ColorNoAlpha] _ReflectionColor ("Color", Vector) = (1,1,1,1)
		_ReflectionSmoothness ("Smoothness", Range(0, 1)) = 0.5
		_FresnelMin ("Fresnel Min", Range(0, 2)) = 0
		_FresnelMax ("Fresnel Max", Range(0, 2)) = 1.5
		[TCP2Separator] [TCP2HeaderHelp(Ambient Lighting)] [Toggle(TCP2_AMBIENT)] _UseAmbient ("Enable Ambient/Indirect Diffuse", Float) = 0
		_TCP2_AMBIENT_RIGHT ("+X (Right)", Vector) = (0,0,0,1)
		_TCP2_AMBIENT_LEFT ("-X (Left)", Vector) = (0,0,0,1)
		_TCP2_AMBIENT_TOP ("+Y (Top)", Vector) = (0,0,0,1)
		_TCP2_AMBIENT_BOTTOM ("-Y (Bottom)", Vector) = (0,0,0,1)
		_TCP2_AMBIENT_FRONT ("+Z (Front)", Vector) = (0,0,0,1)
		_TCP2_AMBIENT_BACK ("-Z (Back)", Vector) = (0,0,0,1)
		[TCP2Separator] [TCP2HeaderHelp(Normal Mapping)] [Toggle(_NORMALMAP)] _UseNormalMap ("Enable Normal Mapping", Float) = 0
		[NoScaleOffset] _BumpMap ("Normal Map", 2D) = "bump" {}
		_NormalMap02 ("Normal Map 02", 2D) = "white" {}
		_NormalMap ("Normal Map Range", Range(0, 1)) = 1
		[TCP2Separator] [HideInInspector] _TintColor ("Tint Color", Vector) = (1,1,1,0)
		[TCP2Separator] [HideInInspector] __dummy__ ("unused", Float) = 0
	}
	
	//DummyShaderTextExporter - One Sided
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0
		sampler2D _MainTex;
		float _Cutoff;
		struct Input
		{
			float2 uv_MainTex;
		};
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			clip(c.a - _Cutoff);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ToonyColorsPro.ShaderGenerator.MaterialInspector_SG2"
}