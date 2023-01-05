using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    [SerializeField] private bool night = false;
    public List<GameObject> targetList;
    private void Start()
    {
        targetList = new List<GameObject>(Resources.LoadAll<GameObject>("ccadori/Vector Forest Scenery/Prefabs/Dinamic/Green-Trees"));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SpawnPrefab();
        if (Input.GetKeyDown(KeyCode.R))
            GameManager.Instance.ResetMap();
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
