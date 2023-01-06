using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InsectManager : MonoBehaviour{
    public List<Insect> insectsList;
    [Tooltip("Number max of Insect on the map")]public int maxNb;
    [Tooltip("x in %")]public int wormSpawn;
    [Tooltip("Each time x insect are eaten, number max decrease by 'removeMax'")]public int insectEatInARow;
    public int removeMax;
    void Start() {
        for (int i = 0; i < maxNb; i++) {
            InstanceInsect();
        }
    }
    void Update() {
        if (GameManager.Instance.InsectList.Count < maxNb) {
            InstanceInsect();
        }
        if (GameManager.Instance.insectEatInARow == insectEatInARow) {
            maxNb -= removeMax;
            GameManager.Instance.insectEatInARow = 0;
        }
    }
    void InstanceInsect() {
        int temp = Random.Range(0, 100);
        if (temp < wormSpawn) temp = Random.Range(0,4);
        else temp = 4;
        Vector2 pos = GameManager.Instance.GenerateVector();
        GameManager.Instance.InsectList.Add(Instantiate(insectsList[temp], pos * GameManager.Instance.mapRatio, Quaternion.identity));
        GameManager.Instance.InsectList[GameManager.Instance.InsectList.Count - 1].pos = pos;
        GameManager.Instance.InsectList[GameManager.Instance.InsectList.Count - 1].GetComponent<SortingGroup>().sortingOrder = (GameManager.Instance.sizeMapY - (int)pos.y) * 10;
    }
}
