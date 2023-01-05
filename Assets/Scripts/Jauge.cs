using UnityEngine;
using UnityEngine.UI;

public class Jauge : MonoBehaviour {

    public float Progression { get; private set; }

    public float ProgressionNormalized {
        get {
            return Mathf.InverseLerp(GameManager.Instance.MinJauge, GameManager.Instance.MaxJauge, Progression);
        }
    }

    public void AddProgression(int value) {
        Progression += value;
        this.gameObject.GetComponent<Image>().material.SetFloat("_Progression", ProgressionNormalized);
    }
}