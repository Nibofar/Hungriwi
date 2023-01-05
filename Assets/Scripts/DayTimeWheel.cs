using UnityEngine;

public class DayTimeWheel : MonoBehaviour {

    private void Update() {
        Quaternion rot = Quaternion.identity;
        rot = Quaternion.Euler(0, 0, Mathf.InverseLerp(0, DayManager.TimePerDay, DayManager.Instance.GameTime % DayManager.TimePerDay) * 360);
        transform.rotation = rot;
    }
}
