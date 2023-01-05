using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithKiwi : MonoBehaviour
{
    public Animator _animator;
    [SerializeField] int r;
    [SerializeField] private GameObject fruit;
    [SerializeField] private GameObject insect;
    [SerializeField] private GameObject kiwi;
    private Vector2 pos;
    private bool bonked;

    private void Start()
    {
        r = Random.Range(1, 6);
        bonked = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pos = kiwi.GetComponent<Transform>().position;
            Shake();
            if (r <= 1 && bonked == false)
            {
                Instantiate<GameObject>(insect, new Vector2(pos.x, pos.y +2), Quaternion.identity);
                bonked = true;
            }
            else if (r >= 2 && bonked == false)
            {
                Instantiate<GameObject>(fruit, new Vector2(pos.x, pos.y +2), Quaternion.identity);
                bonked = true;
            }
            else return;
        }
    }

    public void Shake()
    {
        _animator.SetTrigger("Shake");
    }

}
