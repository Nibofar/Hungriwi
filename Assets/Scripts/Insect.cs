using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum InsectType { worm, spider }
public class Insect : MonoBehaviour{
    public InsectType type;
    public Slider slider;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (type == InsectType.worm) {
            slider.value -= 1;
        }else {
            slider.value -= 2;
        }
        Mathf.Clamp(slider.value, 0, 20);
        Destroy(gameObject);
    }
}