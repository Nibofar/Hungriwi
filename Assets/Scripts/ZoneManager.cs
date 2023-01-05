using UnityEngine;

public class ZoneManager : MonoBehaviour {
    [SerializeField] Transform center;
    [SerializeField] [Min(0.01f)]       float radius = 3.0f;
    [SerializeField] [Min(0.01f)]       float tile = .4f;
    [SerializeField] [Range(0.01f, 1f)]    float step = 0.01f;
    [SerializeField] [Range(0.01f, 1f)]    float smoothStep = 0.06f;
    [SerializeField] [Min(0.01f)]       float edgeWidth = 0.01f;
    [SerializeField] [Min(0.01f)]       float noiseSpeed = 0.1f;
    [SerializeField] 
    [ColorUsage(true, true)] Color edgeColor = Color.white;

    void Update() {
        Shader.SetGlobalVector("_Position", center.position);
        Shader.SetGlobalFloat("_Radius", radius);
        Shader.SetGlobalFloat("_Tile", tile);
        Shader.SetGlobalFloat("_Step", step);
        Shader.SetGlobalFloat("_SmoothStep", smoothStep);
        Shader.SetGlobalFloat("_EdgeWidth", edgeWidth);
        Shader.SetGlobalFloat("_NoiseSpeed", noiseSpeed);
        Shader.SetGlobalColor("_EdgeColor", edgeColor);
    }
}
