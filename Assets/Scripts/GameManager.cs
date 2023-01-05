using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState {
        Boot,
        MainMenu,
        InGame,
        Pause,
        GameOver,
        Credit
    }

    public static GameManager Instance { get; private set; }
    public GameState CurrentGameState { get; private set; }
    public GameState PreviousGameState { get; private set; }

    public delegate void GameStateChangeHandler(GameState newState);
    public event GameStateChangeHandler OnGameStateChanged;


    [SerializeField] float maxJauge = 10.0f;
    [SerializeField] float minJauge = 0.0f;


    public float MaxJauge { get { return maxJauge; } }
    public float MinJauge { get { return minJauge; } }

    private void OnValidate() {
        if (minJauge > maxJauge) minJauge = maxJauge;
        if (maxJauge < minJauge) maxJauge = minJauge;
    }

    void Awake() {
        if(!Instance) Instance = this;
    }
    public void SetState(GameState newState) {
        if (newState == CurrentGameState) return;
        PreviousGameState = CurrentGameState;
        CurrentGameState = newState;
        OnGameStateChanged?.Invoke(newState);
    }
}
