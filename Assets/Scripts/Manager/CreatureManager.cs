using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CreatureManager : MonoBehaviour
{
    public int creatureMin;
    public int creatureMax;
    List<GameObject> targetList;
    private void Start()
    {
        targetList = new List<GameObject>(Resources.LoadAll<GameObject>("ccadori/Vector Forest Scenery/Prefabs/Dinamic/Creatures"));
        SpawnPrefab();
    }
    public void SpawnPrefab()
    {
        int j = Random.Range(creatureMin, creatureMax);
        for (int i = 0; i <= j; i++)
        {
            int k = Random.Range(0, targetList.Count);
            Vector2 pos = GameManager.Instance.GenerateVector();
            GameObject nuCreature = Instantiate(targetList[k], pos * GameManager.Instance.mapRatio, Quaternion.identity);
            nuCreature.GetComponent<SortingGroup>().sortingOrder = (GameManager.Instance.sizeMapY - (int)pos.y) * 10;
            GameManager.Instance.CreatureList.Add(nuCreature);
        }
    }
}
