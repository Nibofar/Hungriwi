using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] Jauge eatingJauge;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject InGame;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Credit;
    public static UIManager Instance { get; private set; }

    void Awake() {
        if(!Instance) Instance = this;
    }
    void Start() {
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    void OnGameStateChanged(GameManager.GameState newState) {

    }

    public void AddJaugeProgression(int value) {
        eatingJauge.AddProgression(value);
    }
    public void ToPlay() {
        InGame.SetActive(true);
        Pause.SetActive(false);
        MainMenu.SetActive(false);
    }
    public void ToMainMenu() {
        MainMenu.SetActive(true);
        Credit.SetActive(false);
    }
    public void ToPause() {
        Pause.SetActive(true);
        InGame.SetActive(false);
    }
    public void ToCredit() {
        Credit.SetActive(true);
        MainMenu.SetActive(false);
    }
}
