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
    [HideInInspector] public List<Insect> InsectList;
    public int insectEatInARow;

    [Header("Eating Jauge")]
    [Tooltip("Nombre de point max pour la jauge")]
    [SerializeField] int maxJauge = 10;
    [Tooltip("Nombre quand la jauge doit changer au rouge")]
    [SerializeField] int dangerLimitMin = 2;
    [Tooltip("Nombre quand la jauge doit changer au vert")]
    [SerializeField] int dangerLimitMax = 5;

    public float MaxJauge { get { return maxJauge; } }
    public float DangerLimitMin { get { return dangerLimitMin; } }
    public float DangerLimitMax { get { return dangerLimitMax; } }

    private void OnValidate() {
        if (maxJauge < 0) maxJauge = 0;
        if (dangerLimitMin < 0) dangerLimitMax = 0;
        if (dangerLimitMax < dangerLimitMin) dangerLimitMax = dangerLimitMin;
        if (dangerLimitMax > maxJauge) dangerLimitMax = maxJauge;
    }

    void Awake() {
        if(!Instance) Instance = this;
        propsData = new bool[sizeMapX, sizeMapY];
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) ResetMap();
    }
    public void SetState(GameState newState) {
        if (newState == CurrentGameState) return;
        PreviousGameState = CurrentGameState;
        CurrentGameState = newState;
        OnGameStateChanged?.Invoke(newState);
    }
    public void SetPropsData(int x, int y, bool state) {
        propsData[x, y] = true;
    }
    public Vector2 GenerateVector() {
        int x = Random.Range(0, sizeMapX);
        int y = Random.Range(0, sizeMapY);
        Vector2 temp = new Vector2(x, y);
        if (propsData[x, y]) {
            temp = GenerateVector();
        }
        SetPropsData(x, y, true);
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
            Destroy(InsectList[i].gameObject);
        }
        InsectList.Clear();
    }
    public void AddJaugeProgression(int value) {
        UIManager.Instance.AddJaugeProgression(value);
    }
}
