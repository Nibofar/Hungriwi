using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesManager : MonoBehaviour{
    public GameObject Eyes;
    public float timeBetweenEyes;
    float timer = 0;
    void Update(){
        timer += Time.deltaTime;
        if(timer >= timeBetweenEyes) {
            Instantiate(Eyes, GenerateEyesPos(), Quaternion.identity);
            timer = 0;
        }
    }
    public Vector2 GenerateEyesPos() {
        int x = Random.Range(1, GameManager.Instance.sizeMapX);
        int y = Random.Range(1, GameManager.Instance.sizeMapY);
        Vector2 temp = new Vector2(x, y);
        if (GameManager.Instance.propsData[x, y]) {
            return temp;
        }
        return GenerateEyesPos();
    }
}

