using UnityEngine;

public class DayManager : MonoBehaviour {
    public enum DayState {
        Day,
        Night
    }

    public static DayManager Instance { get; private set; }
    public DayState CurrentDayState { get; private set; }

    public delegate void DayStateChangeHandler(DayState newState);
    public event DayStateChangeHandler OnDayStateChanged;

    
    public DayState firstState = DayState.Day;
    [Tooltip("x min per sec")]
    [SerializeField] private float daySpeed = 1;
    [Tooltip("x min per sec")]
    [SerializeField] private float nightSpeed = 1;

    public float GameTime { get; private set; }
    public float SequenceTime { get; private set; }
    public float DeltaGameTime { get; private set; }
    public const float TimePerDay = 60.0f * 60.0f * 24.0f;

    public float SequenceProgression { 
        get {
            if (CurrentDayState == DayState.Day) return 1.0f;
            return SequenceTime / (TimePerDay * 0.5f);
        }
    }


    private void Awake() {
        if (!Instance) Instance = this;
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
        this.OnDayStateChanged += OnDayStateChangedFunc;
        CurrentDayState = firstState;
        OnDayStateChanged?.Invoke(firstState);
    }
    private void Update() {
        ZoneManager.Instance.SetRadius(SequenceProgression);
        if (CurrentDayState == DayState.Day)    DeltaGameTime = Time.deltaTime * daySpeed * 60.0f;
        else DeltaGameTime = Time.deltaTime* nightSpeed * 60.0f;


        GameTime += DeltaGameTime;
        SequenceTime += DeltaGameTime;
        if (SequenceTime > TimePerDay * 0.5f) {
            SequenceTime %= TimePerDay * 0.5f;
            if (CurrentDayState == DayState.Day) SetState(DayState.Night);
            else SetState(DayState.Day);
        }


        if (CurrentDayState == DayState.Night) return;

        GameManager.Instance.AddJaugeProgression(-(DeltaGameTime / (GameManager.Instance.MinuteToLooseScore * 60.0f)));
    }
    public void SetState(DayState newState) {
        if (newState == CurrentDayState) return;
        CurrentDayState = newState;
        OnDayStateChanged?.Invoke(newState);
    }
    void OnDayStateChangedFunc(DayState newState) {
        switch (newState) {
            case DayState.Day:
                break;
            case DayState.Night:
                break;
        }
    }

    public void RewindTime(int score) {
        float totalScore = -GameManager.Instance.RewindTimePerScore * score * 60.0f;
        GameTime += totalScore;
        SequenceTime += totalScore;
    }

    public void OnGameStateChanged(GameManager.GameState newState) {
        switch (newState) {
            case GameManager.GameState.InGame:
                enabled = true;
                break;
            default:
                enabled = false;
                break;
        }
    }
}
