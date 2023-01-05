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
