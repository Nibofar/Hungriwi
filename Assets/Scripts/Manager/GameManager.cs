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
    [Tooltip("Distance between props")]public float mapRatio;
    [HideInInspector] public bool[,] propsData;
    [HideInInspector] public List<GameObject> TreeList;
    [HideInInspector] public List<GameObject> CreatureList;
    [HideInInspector] public List<GameObject> DecorList;
    [HideInInspector] public List<Insect> InsectList;
    [HideInInspector] public int insectEatInARow;

    [Header("Eating Jauge")]
    [Tooltip("Nombre de point max pour la jauge")]
    [SerializeField] int maxJauge = 10;
    [Tooltip("Nombre quand la jauge doit changer au rouge")]
    [SerializeField] int dangerLimitMin = 2;
    [Tooltip("Nombre quand la jauge doit changer au vert")]
    [SerializeField] int dangerLimitMax = 5;
    [Tooltip("Score - 1 pour les x temps en min")]
    [SerializeField] float minuteToLooseScore = 60.0f;
    [Tooltip("Temps in Game en min par score de jauge")]
    [SerializeField] float rewindTimePerScore = 60.0f;

    [Header("Vision Radius")]
    [SerializeField] [Min(0.01f)]   float radiusMin = 3.0f;
    [SerializeField]                float radiusMax = 10.0f;
    [SerializeField]                float dayRadius = 15.0f;

    public int MaxJauge { get { return maxJauge; } }
    public int DangerLimitMin { get { return dangerLimitMin; } }
    public int DangerLimitMax { get { return dangerLimitMax; } }
    public float MinuteToLooseScore { get { return minuteToLooseScore; } }
    public float RewindTimePerScore { get { return rewindTimePerScore; } }
    public float RadiusMin { get { return radiusMin; } }
    public float RadiusMax { get { return radiusMax; } }
    public float DayRadius { get { return dayRadius; } }

    private void OnValidate() {
        if (maxJauge < 0) maxJauge = 0;
        if (dangerLimitMin < 0) dangerLimitMax = 0;
        if (dangerLimitMax < dangerLimitMin) dangerLimitMax = dangerLimitMin;
        if (dangerLimitMax > maxJauge) dangerLimitMax = maxJauge;
        if (radiusMax < radiusMin) radiusMax = radiusMin;
        if (radiusMin > radiusMax) radiusMin = radiusMax;
    }

    void Awake() {
        if(!Instance) Instance = this;
        propsData = new bool[sizeMapX, sizeMapY];
        Application.targetFrameRate = 60;
    }
    private void Start() {
        CurrentGameState = GameState.MainMenu;
        OnGameStateChanged?.Invoke(CurrentGameState);
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
        int x = Random.Range(1, sizeMapX);
        int y = Random.Range(1, sizeMapY);
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
        for (int i = 0; i < CreatureList.Count; i++) {
            Destroy(CreatureList[i].gameObject);
        }
        CreatureList.Clear(); 
        for (int i = 0; i < DecorList.Count; i++)
        {
            Destroy(DecorList[i].gameObject);
        }
        DecorList.Clear();
    }
    public void AddJaugeProgression(float value) {
        UIManager.Instance.AddJaugeProgression(value);
    }
}
