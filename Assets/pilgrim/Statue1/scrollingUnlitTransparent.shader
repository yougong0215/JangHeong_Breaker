// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Unlit/Transparent,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:6,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33066,y:32678,varname:node_3138,prsc:2|emission-3351-RGB;n:type:ShaderForge.SFN_Tex2d,id:3351,x:32810,y:32698,varname:node_3351,prsc:2,tex:3781d7eaeaf133c4ab492e3dc951e965,ntxv:0,isnm:False|UVIN-5554-UVOUT,TEX-4747-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:4747,x:32410,y:32735,ptovrint:False,ptlb:node_4747,ptin:_node_4747,varname:node_4747,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3781d7eaeaf133c4ab492e3dc951e965,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:9781,x:32442,y:32982,ptovrint:False,ptlb:asdfds,ptin:_asdfds,varname:node_9781,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4017094,max:1;n:type:ShaderForge.SFN_Panner,id:51,x:32740,y:33149,varname:node_51,prsc:2,spu:1,spv:1;n:type:ShaderForge.SFN_TexCoord,id:5546,x:32424,y:32466,varname:node_5546,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:5554,x:32673,y:32502,varname:node_5554,prsc:2,spu:0,spv:-1|UVIN-5546-UVOUT;proporder:4747;pass:END;sub:END;*/

Shader "Shader Forge/scrollingUnlitTransparent" {
    Properties {
        _node_4747 ("node_4747", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcColor
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_4747; uniform float4 _node_4747_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_9872 = _Time;
                float2 node_5554 = (i.uv0+node_9872.g*float2(0,-1));
                float4 node_3351 = tex2D(_node_4747,TRANSFORM_TEX(node_5554, _node_4747));
                float3 emissive = node_3351.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Unlit/Transparent"
    CustomEditor "ShaderForgeMaterialInspector"
}
