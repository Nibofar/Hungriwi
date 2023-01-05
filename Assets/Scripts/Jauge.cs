using UnityEngine;
using UnityEngine.UI;

public class Jauge : MonoBehaviour {

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

    private void Update() {
        AddProgression((int)Input.GetAxis("Horizontal"));
    }
    public void AddProgression(int value) {
        Progression += value;
        this.gameObject.GetComponent<Image>().material.SetFloat("_Progression", ProgressionNormalized);
        this.gameObject.GetComponent<Image>().material.SetFloat("_Limit", LimitNormalized);
        Debug.Log(LimitNormalized);
    }
}