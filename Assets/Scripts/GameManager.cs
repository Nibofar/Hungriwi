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

    [Header("Map")]
    public int sizeMapX;
    public int sizeMapY;
    public float mapRatio;
    [HideInInspector] public bool[,] propsData;
    public int treeMin;
    public int treeMax;
    [HideInInspector] public List<GameObject> TreeList;
    [HideInInspector] public List<GameObject> InsectList;

    [Header("Eating Jauge")]
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
        propsData = new bool[sizeMapX, sizeMapY];
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
    public Vector2 GenerateVector() {
        int x = Random.Range(0, sizeMapX);
        int y = Random.Range(0, sizeMapY);
        Vector2 temp = new Vector2(x, y);
        if (propsData[x, y]) {
            temp = GenerateVector();
        }
        SetPropsData(x, y);
        return temp;
    }
    public void ResetMap() {
        for(int i = 0; i < sizeMapX; i++) {
            for(int j = 0; j < sizeMapY; j++) {
                propsData[i, j] = false;
            }
        }
        for(int i = 0; i < TreeList.Count; i++) {
            Destroy(TreeList[i]);
        }
        TreeList.Clear();
        for (int i = 0; i < InsectList.Count; i++) {
            Destroy(InsectList[i]);
        }
        InsectList.Clear();
    }
    public void AddJaugeProgression(int value) {
        UIManager.Instance.AddJaugeProgression(value);
    }
}
