using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load your gameplay scene, replace "GameScene" with your scene's name
        SceneManager.LoadScene("LevelOne");
    }

    public void HowToPlay()
    {
        // Load the how-to-play scene or show a UI panel
        SceneManager.LoadScene("HowToPlay");
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // So it exits play mode in editor
#endif
    }
}
