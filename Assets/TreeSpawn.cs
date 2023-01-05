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

    }
    public void SpawnPrefab()
    {
        int j = Random.Range(5, 8);
        for (int i = 0; i <= j; i++)
        {
            float x = Random.Range(-9, 9);
            float y = Random.Range(-5, 5);
            Instantiate(tree, new Vector2(x, y), Quaternion.identity);

        }

    }

}
