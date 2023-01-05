using UnityEngine;

public class DayTimeWheel : MonoBehaviour {

    private void Update() {
        transform.Rotate(Vector3.forward * DayManager.Instance.Delta);
    }
}
