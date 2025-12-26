using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int mainMenuBuildIndex = 1;      // индекс главного меню
    public int maxAmmo = 5;
    public int currentAmmo;
    public int maxStamina = 10;
    public int currentStamina;

    public float deathRestartDelay = 3f;    // сколько секунд показывать видео
    public VideoPlayer deathVideoPlayer;    // объект с роликом "вы умерли"

    private bool isDead = false;
    private Rigidbody2D rb;

    void Awake()
    {
        currentHealth = maxHealth;
        currentAmmo = maxAmmo;
        currentStamina = maxStamina;

        rb = GetComponent<Rigidbody2D>();
    }

    // ВЫНОСЛИВОСТЬ
    public bool UseStamina(int amount)
    {
        if (currentStamina < amount)
            return false;

        currentStamina -= amount;
        return true;
    }

    // ПАТРОНЫ
    public bool UseAmmo(int amount)
    {
        if (currentAmmo < amount)
            return false;

        currentAmmo -= amount;
        return true;
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
    }

    // ПОЛУЧЕНИЕ УРОНА
    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    // СМЕРТЬ + ВИДЕО + ПЕРЕХОД В МЕНЮ
    void Die()
    {
        if (isDead) return;
        isDead = true;

        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        // показываем видео "вы умерли"
        if (deathVideoPlayer != null)
        {
            deathVideoPlayer.gameObject.SetActive(true);
            deathVideoPlayer.playOnAwake = false;
            deathVideoPlayer.Stop();
            deathVideoPlayer.Play();
        }

        Invoke(nameof(LoadMainMenu), deathRestartDelay);
        Console.WriteLine("loo");
    }

    void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuBuildIndex);
    }
}
