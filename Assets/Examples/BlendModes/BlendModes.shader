Shader "Hubris/Camera/BlendModes"
{
	Properties
	{
		_MainTex("-", 2D) = "" {}
	}
	

	CGINCLUDE
	#include "UnityCG.cginc"

	//#include "../../Hubris/CG/AllIncs.hlsl"

	sampler2D _MainTex;

	sampler2D _SecondTex;


//#include "../../Hubris/HLSL/HubrisHLSL.hlsl"
#include "../../Hubris/HLSL/GPU.hlsl"


	



	half4 frag(v2f_img i) : SV_Target
	{
	/*	half4 cam = tex2D(_MainTex, i.uv);
		half4 tex = tex2D(gustavTex, i.uv);*/
		//half4 blend = Hubris::blend(tex, cam, blendMode, composite, coverage);
		//return half4(blend.rgb, 1.0);
		// return Hubris::ShiftHSV(cam, 0.5, 1.0, 0.0);



		//half3 kuler = 0.0;
		//float2 v = i.uv;
		//v.y -= 0.25;
		//v.y *= 2;

		//v.x = Hubris::Ease(i.uv.x * 2, ease);
		//kuler.r += smoothstep(v.x - lineWeight, v.x, v.y) * smoothstep(v.x + lineWeight, v.x, v.y);
		//v.x = Hubris::Ease(i.uv.x * 2, ease + 1);
		//kuler.g += smoothstep(v.x - lineWeight, v.x, v.y) * smoothstep(v.x + lineWeight, v.x, v.y);
		//v.x = Hubris::Ease(i.uv.x * 2, ease + 2);
		//kuler.b += smoothstep(v.x - lineWeight, v.x, v.y) * smoothstep(v.x + lineWeight, v.x, v.y);

		// return half4(kuler, 1.0);

		float4 xyzw = 0.0;
		xyzw.xy = i.uv * 10.0;
		xyzw.zw = time;

		float2 shift;
		shift.x = Hubris::Noise(noise, xyzw, fallOff, angle, t, ridgeOffset, octaves, lacunarity, gain);

		xyzw.xy = i.uv * 10.0 + float2(23.0, 7.0);
		xyzw.zw = time + float2(5.0, 13.0);

		shift.y = Hubris::Noise(noise, xyzw, fallOff, angle, t, ridgeOffset, octaves, lacunarity, gain);
		shift += i.uv;

			return tex2D(_MainTex, shift);

	}

	ENDCG
	SubShader
	{
		Pass
		{
			ZTest Always Cull Off ZWrite Off
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			//#pragma target 4.0
			ENDCG
		}
	}
}