using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Synecdoche/Camera/Easing")]
public class Easing : MonoBehaviour
{
    private Material mat;
    private int easeSettingsID;

    public Synecdoche.HLSL.Easing ease;
    [Range(0f, 1f)]
    public float lineWeight;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (mat == null)
        {
            mat = new Material(Shader.Find("Hidden/Synecdoche/Camera/Easing"))
            {
                hideFlags = HideFlags.DontSave
            };

            easeSettingsID = Shader.PropertyToID("easeSettings");
        }

        mat.SetVector(easeSettingsID, new Vector4((int) ease, lineWeight, 0, 0));

        Graphics.Blit(source, destination, mat);
    }
}