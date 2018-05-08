Shader "Custom/Transparent Sprite" 
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _BumpMap ("Normalmap", 2D) = "bump" {}
        _BumpIntensity("NormalMap Intensity", Float) = 1
        _Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
 
    SubShader
    {
        Tags
        {
            "Queue"="AlphaTest"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
 
        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha
 
        CGPROGRAM
        #pragma surface surf Lambert vertex:vert nofog alphatest:_Cutoff addshadow
        #pragma multi_compile _ PIXELSNAP_ON
 
        sampler2D _MainTex;
        sampler2D _BumpMap;
        fixed4 _Color;
        fixed _BumpIntensity;
 
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            fixed4 color;
        };
       
        void vert (inout appdata_full v, out Input o)
        {
            #if defined(PIXELSNAP_ON)
            v.vertex = UnityPixelSnap (v.vertex);
            #endif
           
            UNITY_INITIALIZE_OUTPUT(Input, o);
            o.color = v.color * _Color;
        }
 
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * IN.color;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            _BumpIntensity = 1 / _BumpIntensity;
            o.Normal.z = o.Normal.z * _BumpIntensity;
            o.Normal = normalize((half3)o.Normal);
            o.Albedo = c.rgb * c.a;
            o.Alpha = c.a;
        }
        ENDCG
    }
 
Fallback "Transparent/Cutout/VertexLit"
}