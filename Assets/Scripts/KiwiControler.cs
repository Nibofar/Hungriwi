using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiControler : MonoBehaviour{
    public float speed;
    Vector3 direction = new Vector2(0, 0);
    void Start()
    {
        
    }
    void Update(){
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        if (direction.x == 1) { 
            if(direction.y == 1) {
                direction.x = 0.707f;
                direction.y = 0.707f;
            } else if (direction.y == -1) {
                direction.x = 0.707f;
                direction.y = -0.707f;
            }
        } else if (direction.x == -1) {
            if (direction.y == 1) {
                direction.x = -0.707f;
                direction.y = 0.707f;
            } else if (direction.y == -1) {
                direction.x = -0.707f;
                direction.y = -0.707f;
            }
        }
        transform.position += direction * Time.deltaTime * speed;
    }
}
