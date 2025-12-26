using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 8f;
    public float fireInterval = 2f;

    private float timer;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            timer = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        // ����� �������� �����
        brb.linearVelocity = Vector2.left * bulletSpeed;
    }
}
