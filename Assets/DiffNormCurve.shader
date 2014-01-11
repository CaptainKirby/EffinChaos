Shader "Custom/DiffNormCurve" {
	Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
			_QOffset ("Offset", Vector) = (0,0,0,0)
		_Dist ("Distance", Float) = 100.0
	}


  SubShader {

    Tags { "RenderType" = "Opaque" }
    LOD 300

    CGPROGRAM

    #pragma surface surf Lambert vertex:vert 
	sampler2D _MainTex;
	sampler2D _BumpMap;
	fixed4 _Color;
	float4 _QOffset;
	float _Dist;
	
    struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
    };

    void vert (inout appdata_full v) {
    	float4 vPos =  v.vertex; // mul(_World2Object,v.vertex);
    	float zOff = vPos.z/_Dist;
    	vPos += _QOffset*zOff*zOff;
    	
    	v.vertex = vPos;
 
 
 		// ??? What to do here ???
		
        //v2f o;
	    //float4 vPos = mul (UNITY_MATRIX_MV, v.vertex);
	    //float zOff = vPos.z/_Dist;
	   // vPos += _QOffset*zOff*zOff;
	  //  o.pos = mul (UNITY_MATRIX_P, vPos);
	   // o.uv = v.texcoord;
	  //  return o;

    }

    void surf (Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
		o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
    }

    ENDCG

  }

  Fallback "Diffuse"

}