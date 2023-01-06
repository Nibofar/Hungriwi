using UnityEngine;

public class Insect : MonoBehaviour{
    public enum InsectType { worm = 1, spider = 2 }
    public InsectType type;
    public AudioSource crunch;
    [HideInInspector]public Vector2 pos;
    private void OnTriggerEnter2D(Collider2D collision) {
        Instantiate(crunch, pos, Quaternion.identity);
        GameManager.Instance.AddJaugeProgression((int)type);
        DayManager.Instance.RewindTime((int)type);
        GameManager.Instance.SetPropsData((int)pos.x, (int)pos.y, false);
        GameManager.Instance.insectEatInARow++;
        GameManager.Instance.InsectList.Remove(this);
        Destroy(gameObject, crunch.time);
    }
}