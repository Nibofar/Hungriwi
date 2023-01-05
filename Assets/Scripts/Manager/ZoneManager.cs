using UnityEngine;

public class ZoneManager : MonoBehaviour {
    [SerializeField] Transform center;
    [SerializeField] [Min(0.01f)]       float radius = 2;
    [SerializeField] [Min(0.01f)]       float tile = 1;
    [SerializeField] [Range(0f, 1f)]    float step = 0.05f;
    [SerializeField] [Min(0.01f)]       float edgeWidth = 1f;
    [SerializeField] [Min(0.01f)]       float noiseSpeed = 0.1f;
    [SerializeField] 
    [ColorUsage(true, true)] Color edgeColor = Color.white;

    void Update() {
        Shader.SetGlobalVector("_Position", center.position);
        Shader.SetGlobalFloat("_Radius", radius);
        Shader.SetGlobalFloat("_Tile", tile);
        Shader.SetGlobalFloat("_Step", step);
        Shader.SetGlobalFloat("_NoiseSpeed", noiseSpeed);
        Shader.SetGlobalFloat("_EdgeWidth", edgeWidth);
        Shader.SetGlobalColor("_EdgeColor", edgeColor);
    }
}
