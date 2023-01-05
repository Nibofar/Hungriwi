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

    private float speed = 1;
    public float GameTime { get; private set; }
    public float SequenceTime { get; private set; }
    public float HourTime { get; private set; }
    public float DeltaGameTime { get; private set; }
    public const float TimePerDay = 60.0f * 60.0f * 24.0f;


    private void Awake() {
        if (!Instance) Instance = this;
        this.OnDayStateChanged += OnDayStateChangedFunc;
        CurrentDayState = firstState;
        OnDayStateChanged?.Invoke(firstState);
    }
    private void Update() {
        DeltaGameTime = Time.deltaTime* speed * 60.0f;
        GameTime += DeltaGameTime;
        SequenceTime += DeltaGameTime;
        if(SequenceTime > TimePerDay * 0.5f) {
            SequenceTime %= TimePerDay * 0.5f;
            if (CurrentDayState == DayState.Day) SetState(DayState.Night);
            else SetState(DayState.Day);
        }


        if (CurrentDayState == DayState.Day) return;

        HourTime += DeltaGameTime;
        if(HourTime > 60.0f * 60.0f) {
            HourTime %= 60.0f * 60.0f;
            GameManager.Instance.AddJaugeProgression(-GameManager.Instance.ScoreLoosePerHour);
        }
    }
    public void SetState(DayState newState) {
        if (newState == CurrentDayState) return;
        CurrentDayState = newState;
        OnDayStateChanged?.Invoke(newState);
    }
    void OnDayStateChangedFunc(DayState newState) {
        switch (newState) {
            case DayState.Day:
                speed = daySpeed;
                break;
            case DayState.Night:
                speed = nightSpeed;
                break;
        }
    }

    public void RewindTime(int score) {
        float totalScore = -GameManager.Instance.RewindTimePerScore * score * 60.0f;
        GameTime += totalScore;
        SequenceTime += totalScore;
    }
}
