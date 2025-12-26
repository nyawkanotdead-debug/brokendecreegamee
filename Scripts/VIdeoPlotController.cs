using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Videoplotconreoller : MonoBehaviour
{
    public VideoPlayer videoPlayer;   // компонент VideoPlayer
    public int mainMenuBuildIndex = 3; // индекс сцены главного меню

    void Start()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        LoadMainMenu();
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuBuildIndex);
    }
}
