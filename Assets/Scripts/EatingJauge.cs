using UnityEngine;
using UnityEngine.UI;

public class EatingJauge : MonoBehaviour {

    public float Progression { get; private set; }
    public float ProgressionNormalized {
        get {
            return Mathf.InverseLerp(0, GameManager.Instance.MaxJauge, Progression);
        }
    }
    public float LimitNormalized {
        get {
            return Mathf.InverseLerp(GameManager.Instance.DangerLimitMin, GameManager.Instance.DangerLimitMax, Progression);
        }
    }

    private void Start() {
        AddProgression(GameManager.Instance.MaxJauge);
    }
    public void AddProgression(float value) {
        Progression += value;
        if (Progression <= 0) GameManager.Instance.SetState(GameManager.GameState.GameOver);
        Progression = Mathf.Clamp(Progression, 0, GameManager.Instance.MaxJauge);
        this.gameObject.GetComponent<Image>().material.SetFloat("_Progression", ProgressionNormalized);
        this.gameObject.GetComponent<Image>().material.SetFloat("_Limit", LimitNormalized);
    }
}