using UnityEngine;
using System.Collections.Generic;

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

    public int sizeMapX;
    public int sizeMapY;
    [HideInInspector] public bool[,] propsData;
    public int treeMin;
    public int treeMax;
    [HideInInspector] public List<GameObject> TreeList;

    void Awake() {
        if(!Instance) Instance = this;
        propsData = new bool[sizeMapX * 2, sizeMapY * 2];
    }
    public void SetState(GameState newState) {
        if (newState == CurrentGameState) return;
        PreviousGameState = CurrentGameState;
        CurrentGameState = newState;
        OnGameStateChanged?.Invoke(newState);
    }
    public void SetPropsData(int x, int y) {
        propsData[x, y] = true;
    }
    public void ResetTree() {
        for(int i = 0; i < TreeList.Count; i++) {
            Destroy(TreeList[i]);
        }
        TreeList.Clear();
    }
}
