Shader "Hidden/Synecdoche/Camera/Easing"
{
	CGINCLUDE
	#include "UnityCG.cginc"
	#include "../../Synecdoche/HLSL/HLSL.hlsl"

	float4 easeSettings; // Ease, LineWeight, 0, 0


	half4 frag(v2f_img i) : SV_Target
	{
		half3 kuler = 0.0;
		float2 v = i.uv;
		//v.y -= 0.25;
		//v.y *= 2;

		for (int k = 1; k < 2; k += 3)
		{
			half3 temp = 0;

			v.x = Hubris::Ease(i.uv.x, 1);
			kuler.r = smoothstep(v.x - easeSettings.y, v.x, v.y) * smoothstep(v.x + easeSettings.y, v.x, v.y);
			v.x = Hubris::Ease(i.uv.x, 2);
			kuler.g = smoothstep(v.x - easeSettings.y, v.x, v.y) * smoothstep(v.x + easeSettings.y, v.x, v.y);
			v.x = Hubris::Ease(i.uv.x, 3);
			kuler.b = smoothstep(v.x - easeSettings.y, v.x, v.y) * smoothstep(v.x + easeSettings.y, v.x, v.y);

			// kuler += temp;
		}
	
		return half4(kuler, 1.0);

		// float4 xyzw = 0.0;
		// xyzw.xy = i.uv * 10.0;
		// xyzw.zw = time;

		// float2 shift;
		// shift.x = Hubris::Noise(noise, xyzw, fallOff, angle, t, ridgeOffset, octaves, lacunarity, gain);

		// xyzw.xy = i.uv * 10.0 + float2(23.0, 7.0);
		// xyzw.zw = time + float2(5.0, 13.0);

		// shift.y = Hubris::Noise(noise, xyzw, fallOff, angle, t, ridgeOffset, octaves, lacunarity, gain);
		// shift += i.uv;

		// 	return tex2D(_MainTex, shift);

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