using UnityEngine;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }

    void Awake() {
        if(!Instance) Instance = this;
    }
    void Start() {
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    void OnGameStateChanged(GameManager.GameState newState) {

    }
}
