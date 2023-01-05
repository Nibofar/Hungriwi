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
        if (Input.GetKeyDown(KeyCode.F))
            GameManager.Instance.ResetTree();
    }
    public void SpawnPrefab()
    {
        int j = Random.Range(GameManager.Instance.treeMin, GameManager.Instance.treeMax);
        for (int i = 0; i <= j; i++)
        {
            Vector2 place = GenerateVector();
            GameManager.Instance.SetPropsData((int)place.x + GameManager.Instance.sizeMapX, (int)place.y + GameManager.Instance.sizeMapY);
            GameManager.Instance.TreeList.Add(Instantiate(tree, place, Quaternion.identity));

        }

    }
     Vector2 GenerateVector() {
        int x = Random.Range(-GameManager.Instance.sizeMapX, GameManager.Instance.sizeMapX);
        int y = Random.Range(-GameManager.Instance.sizeMapY, GameManager.Instance.sizeMapY);
        Vector2 temp = new Vector2(x, y);
        if (GameManager.Instance.propsData[x + GameManager.Instance.sizeMapX, y + GameManager.Instance.sizeMapY]) {
            temp = GenerateVector();
        }
        return temp;
    }
}
