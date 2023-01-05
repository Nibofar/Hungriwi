using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    public List<SpriteRenderer> renderers;
    public ParticleSystemRenderer p;
    public void SetLayer(int depth) {
        if(p) p.sortingOrder = depth--;
        foreach (var item in renderers) {
            item.GetComponent<SpriteRenderer>().sortingLayerID = depth--;
        }
    }
}
