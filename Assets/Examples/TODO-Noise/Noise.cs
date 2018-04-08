using UnityEngine;
using Hubris;
using Hubris.HLSL;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Hubris/Camera/Noise")]
public class Noise : MonoBehaviour
{


    public Texture2D gustav;

    Material _material;

    public BlendMode blendMode;
    public PorterDuffComposite composite;
    public Converage coverage;
    public Easing ease;
    public Hubris.HLSL.Mirror mirror;
    public NoiseSimplex noise;

    public float fallOff;
    public float angle;
    public float t;
    public float ridgeOffset;
    public int octaves;
    public float lacunarity;
    public float gain;


    [Range(0, 1)]
    public float lineWeight;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (_material == null)
        {
            _material = new Material(Shader.Find("Hubris/Camera/Noise"))
            {
                hideFlags = HideFlags.DontSave
            };
        }

        _material.SetTexture("_SecondTex", gustav);
        _material.SetInt("blendMode", (int) blendMode);
        _material.SetInt("composite", (int) composite);
        _material.SetInt("coverage", (int)coverage);
        _material.SetInt("ease", (int)ease);
        _material.SetInt("mirror", (int)mirror);



        _material.SetInt("noise", (int)noise);
        _material.SetVector("time", new Vector2(Time.time, Mathf.Sqrt(Time.time)));
        _material.SetFloat("fallOff", fallOff);
        _material.SetFloat("angle", angle);
        _material.SetFloat("t", t);
        _material.SetFloat("ridgeOffset", ridgeOffset);
        _material.SetInt("octaves", octaves);
        _material.SetFloat("lacunarity", lacunarity);
        _material.SetFloat("gain", gain);


        _material.SetFloat("lineWeight", lineWeight);


        Graphics.Blit(source, destination, _material);
    }
}