using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesBehaviour : MonoBehaviour{
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.GetComponent<KiwiControler>()) Destroy(gameObject);
    }
    private void Update() {
        GetComponent<CircleCollider2D>().radius = ZoneManager.Instance.Radius;
    }
}
