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
    }
    void Start() {
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    void OnGameStateChanged(GameManager.GameState newState) {

    }

    public void AddJaugeProgression(float value) {
        eatingJauge.AddProgression(value);
    }
    public void ToPlay() {
        Debug.Log("test");
        InGame.SetActive(true);
        Pause.SetActive(false);
        MainMenu.SetActive(false);
    }
    public void ToMainMenu() {
        MainMenu.SetActive(true);
        Pause.SetActive(false);
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
