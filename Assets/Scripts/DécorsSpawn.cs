using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DécorsSpawn : MonoBehaviour
{
    public int decorMin;
    public int decorMax;
    List<GameObject> targetList;
    private void Start()
    {
        targetList = new List<GameObject>(Resources.LoadAll<GameObject>("ccadori/Vector Forest Scenery/Prefabs/Dinamic/Décors"));
        SpawnPrefab();
    }
    public void SpawnPrefab()
    {
        int j = Random.Range(decorMin, decorMax);
        for (int i = 0; i <= j; i++)
        {
            int k = Random.Range(0, targetList.Count);
            Vector2 pos = GameManager.Instance.GenerateVector();
            GameObject nuTree = Instantiate(targetList[k], pos * GameManager.Instance.mapRatio, Quaternion.identity);
            nuTree.GetComponent<SortingGroup>().sortingOrder = (GameManager.Instance.sizeMapY - (int)pos.y) * 10;
            GameManager.Instance.DecorList.Add(nuTree);
        }
    }
}
