using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveInput;
    private PlayerStats stats;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        moveInput = Input.GetAxisRaw("Horizontal");

        // ТЕСТОВАЯ смерть по ALT (вызывает TakeDamage)
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            stats.TakeDamage(stats.currentHealth); // сразу убивает
        }
    }

    void FixedUpdate()
    {
        // если уже мёртв, двигаться не надо
        if (stats != null && stats.currentHealth <= 0) return;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}
