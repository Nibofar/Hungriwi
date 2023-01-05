using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InsectType { worm, spider }
public class Insect : MonoBehaviour{
    public InsectType type;
    public Vector2 pos;
    private void OnTriggerEnter2D(Collider2D collision) {
        //add value for the jauge
        GameManager.Instance.SetPropsData((int)pos.x, (int)pos.y, false);
        GameManager.Instance.insectEatInARow++;
        GameManager.Instance.InsectList.Remove(this);
        Destroy(gameObject);
    }
}