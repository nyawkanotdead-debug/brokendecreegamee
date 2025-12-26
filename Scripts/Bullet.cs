using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Урон игроку
        if (other.CompareTag("Player"))
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            if (stats != null)
                stats.TakeDamage(damage);
            Destroy(gameObject);
        }

        // Урон врагу
        if (other.CompareTag("Enemy"))
        {
            EnemyStats stats = other.GetComponent<EnemyStats>();
            if (stats != null)
                stats.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
