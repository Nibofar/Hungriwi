using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] EatingJauge eatingJauge;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject InGame;
    [SerializeField] GameObject Pause;
    [SerializeField] GameObject Credit;
    public static UIManager Instance { get; private set; }

    void Awake() {
        if(!Instance) Instance = this;
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    void OnGameStateChanged(GameManager.GameState newState) {
        switch (newState) {
            case GameManager.GameState.InGame:
                ToPlay();
                break;
            case GameManager.GameState.Boot:
                break;
            case GameManager.GameState.MainMenu:
                ToMainMenu();
                break;
            case GameManager.GameState.Pause:
                ToPause();
                break;
            case GameManager.GameState.GameOver:
                break;
            case GameManager.GameState.Credit:
                ToCredit();
                break;
            default:
                enabled = false;
                break;
        }
    }

    public void AddJaugeProgression(float value) {
        eatingJauge.AddProgression(value);
    }
    void ToPlay() {
        InGame.SetActive(true);
        Pause.SetActive(false);
        MainMenu.SetActive(false);
    }
    void ToMainMenu() {
        MainMenu.SetActive(true);
        Pause.SetActive(false);
        Credit.SetActive(false);
    }
    void ToPause() {
        Pause.SetActive(true);
        InGame.SetActive(false);
    }
    void ToCredit() {
        Credit.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void ChangeState(int newState) {
        GameManager.Instance.SetState((GameManager.GameState)newState);
    }
}
