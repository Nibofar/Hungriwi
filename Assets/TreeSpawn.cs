using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    [SerializeField] private bool night = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SpawnPrefab();
        if (Input.GetKeyDown(KeyCode.R))
            GameManager.Instance.ResetTree();
    }
    public void SpawnPrefab()
    {
        int j = Random.Range(GameManager.Instance.treeMin, GameManager.Instance.treeMax);
        for (int i = 0; i <= j; i++)
        {
            Vector2 place = GenerateVector();
            GameManager.Instance.SetPropsData((int)place.x, (int)place.y);
            GameManager.Instance.TreeList.Add(Instantiate(tree, place, Quaternion.identity));

        }

    }
     Vector2 GenerateVector() {
        int x = Random.Range(0, GameManager.Instance.sizeMapX);
        int y = Random.Range(0, GameManager.Instance.sizeMapY);
        Vector2 temp = new Vector2(x, y);
        if (GameManager.Instance.propsData[x, y]) {
            temp = GenerateVector();
        }
        return temp;
    }
}
