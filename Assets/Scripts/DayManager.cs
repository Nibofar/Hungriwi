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
    private float gameTime = 0;
    private float realtime = 0;


    private void Awake() {
        if (!Instance) Instance = this;
        this.OnDayStateChanged += OnDayStateChangedFunc;
        CurrentDayState = (DayState)2;
        SetState(firstState);
    }
    private void Update() {
        gameTime += Time.deltaTime * speed * 60.0f;
        realtime += Time.deltaTime;
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
