using UnityEngine;

public class KiwiControler : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sprite;
    public float speed;
    public bool stunned;
    private float setTimer = 2f;
    private float timer;
    Rigidbody2D rb;

    Vector2 direction = new Vector2(0, 0);
    private void Awake() {
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    void Start() {
        timer = setTimer;
        stunned = false;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        if (DayManager.Instance.CurrentDayState == DayManager.DayState.Day) return;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        if (stunned == true) {
            Debug.Log("stunned " + stunned);
            timer -= Time.deltaTime;
            if (timer <= 0) {
                stunned = false;
                timer = setTimer;
                Debug.Log("stunned " + stunned);
            }


        } else {
            if (direction.x == 1) {
                sprite.flipX = true;
                if (direction.y == 1) {
                    direction.x = 0.707f;
                    direction.y = 0.707f;
                } else if (direction.y == -1) {
                    direction.x = 0.707f;
                    direction.y = -0.707f;
                }
            } else if (direction.x == -1) {
                sprite.flipX = false;
                if (direction.y == 1) {
                    direction.x = -0.707f;
                    direction.y = 0.707f;
                } else if (direction.y == -1) {
                    direction.x = -0.707f;
                    direction.y = -0.707f;
                }
            }
            rb.velocity = rb.velocity + direction * speed * Time.deltaTime;
            rb.velocity *= 0.8f;
            animator.SetFloat("Speed", Mathf.Abs(direction.x));
        }
    }

    public void OnGameStateChanged(GameManager.GameState newState) {
        switch (newState) {
            case GameManager.GameState.InGame:
                enabled = true;
                break;
            default:
                enabled = false;
                break;
        }
    }
}
