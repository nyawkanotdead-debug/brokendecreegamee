using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        // тут можешь добавить анимацию, эффект и т.п.
        Destroy(gameObject);
    }
}
