using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitStun : MonoBehaviour
{
    private KiwiControler kiwi;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<KiwiControler>().stunned = true;
            Destroy(this.gameObject);
        }
    }
}
