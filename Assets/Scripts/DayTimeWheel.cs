using UnityEngine;

public class DayTimeWheel : MonoBehaviour {

    int nightFirst = 0;
    private void Start() {
        if (DayManager.Instance.firstState == DayManager.DayState.Night) nightFirst = 1;
    }
    private void Update() {
        Quaternion rot = Quaternion.Euler(0, 0, Mathf.InverseLerp(0, DayManager.TimePerDay, DayManager.Instance.GameTime % DayManager.TimePerDay) * 360 + nightFirst * 180 );
        transform.rotation = rot;
    }
}
