using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Перетащи сюда AudioSource с музыкой из инспектора
    public AudioSource musicSource;

    private void Start()
    {
        // Запускаем музыку в начале сцены
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.loop = true;      // музыка по кругу
            musicSource.Play();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Console.WriteLine("game started");
    }

    public void OptionGame()
    {

    }

    // Выход из игры
    public void QuitGame()
    {
        Application.Quit();
    }
}
