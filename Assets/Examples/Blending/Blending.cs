using UnityEngine;
using Synecdoche.HLSL;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Synecdoche/Camera/Blending")]
public class Blending : MonoBehaviour
{
    private Material mat;
    private int secondCameraID;
    private int blendSettingsID;

    public RenderTexture secondCamera;
    public BlendMode mode;
    public BlendPorterDuffComposite composite;
    public BlendCoverage coverage;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (mat == null)
        {
            mat = new Material(Shader.Find("Hidden/Synecdoche/Camera/Blending"))
            {
                hideFlags = HideFlags.DontSave
            };

            secondCameraID = Shader.PropertyToID("secondCamera");
            blendSettingsID = Shader.PropertyToID("blendSettings");
        }

        mat.SetTexture(secondCameraID, secondCamera);
        mat.SetVector(blendSettingsID, new Vector4((int) mode, (int) composite, (int) coverage, 0));

        Graphics.Blit(source, destination, mat);
    }
}