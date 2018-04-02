using UnityEngine;
using Hubris;
using Hubris.HLSL;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Hubris/Camera/BlendModes")]
public class BlendModes : MonoBehaviour
{
    public Texture2D gustav;

    Material _material;


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (_material == null)
        {
            _material = new Material(Shader.Find("Hubris/Camera/BlendModes"))
            {
                hideFlags = HideFlags.DontSave
            };
        }

        _material.SetTexture("_SecondTex", gustav);



        Graphics.Blit(source, destination, _material);
    }
}