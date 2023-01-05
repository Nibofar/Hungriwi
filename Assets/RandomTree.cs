using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTree : MonoBehaviour
{
    [SerializeField] private int r;
    [SerializeField] private SpriteRenderer treeSprite;
    void Start()
    {
        treeSprite = this.GetComponent<SpriteRenderer>();
        r = Random.Range(1, 4);
        if (r == 1)
            treeSprite.sprite = Resources.Load<Sprite>("ccadori/Vector Forest Scenery/Sprites/Static/static-tree-type-1-green"); 
        if (r == 2)
            treeSprite.sprite = Resources.Load<Sprite>("ccadori/Vector Forest Scenery/Sprites/Static/static-tree-type-2-green");
        if (r == 3)
            treeSprite.sprite = Resources.Load<Sprite>("ccadori/Vector Forest Scenery/Sprites/Static/static-tree-type-3-green");
        if (r == 4)
            treeSprite.sprite = Resources.Load<Sprite>("ccadori/Vector Forest Scenery/Sprites/Static/static-tree-type-4-green");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
