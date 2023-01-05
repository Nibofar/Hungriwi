using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitStun : MonoBehaviour
{
    [SerializeField] private GameObject kiwi;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }
}
