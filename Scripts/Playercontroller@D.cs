using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform firePoint;     // ����� ��������
    public GameObject bulletPrefab; // ������ ����
    public float bulletSpeed = 10f;

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

        // �������� ���
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Shoot()
    {
        // ������ 1 ������������ � 1 ������
        if (!stats.UseStamina(1)) return;
        if (!stats.UseAmmo(1)) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        brb.linearVelocity = Vector2.right * bulletSpeed * Mathf.Sign(transform.localScale.x);
    }
}
