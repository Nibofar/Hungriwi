using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public List<GameObject> targetList;
    private void Start()
    {
        targetList = new List<GameObject>(Resources.LoadAll<GameObject>("ccadori/Vector Forest Scenery/Prefabs/Dinamic/Green-Trees"));
        SpawnPrefab();
    }
    public void SpawnPrefab()
    {
        int j = Random.Range(GameManager.Instance.treeMin, GameManager.Instance.treeMax);
        for (int i = 0; i <= j; i++)
        {
            int k = Random.Range(0, targetList.Count);
            GameManager.Instance.TreeList.Add(Instantiate(targetList[k], GameManager.Instance.GenerateVector() * GameManager.Instance.mapRatio, Quaternion.identity));
        }
    }
}
