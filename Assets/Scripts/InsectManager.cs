using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectManager : MonoBehaviour{
    public List<Insect> insectsList;
    public int maxNb;
    public int timeRatio;
    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            InstanceInsect();
        }
    }
    void InstanceInsect() {
        for (int i = 0; i < maxNb; i++) {
            int temp = Random.Range(0, 10);
            if (temp < 7) temp = 0;
            else temp = 1;
            GameManager.Instance.InsectList.Add(Instantiate(insectsList[temp].gameObject, GameManager.Instance.GenerateVector() * GameManager.Instance.mapRatio, Quaternion.identity));
        }
    }
}
