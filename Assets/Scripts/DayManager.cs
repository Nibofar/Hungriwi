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
    public float RealTime { get; private set; }
    public float Delta { get; private set; }


    private void Awake() {
        if (!Instance) Instance = this;
        this.OnDayStateChanged += OnDayStateChangedFunc;
        CurrentDayState = firstState;
        OnDayStateChanged?.Invoke(firstState);
    }
    private void Update() {
        Delta = Time.deltaTime* speed *60.0f;
        GameTime += Delta;
        RealTime += Time.deltaTime;
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
}
