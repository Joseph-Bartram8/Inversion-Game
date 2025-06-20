using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Lock the cursor and hide it for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Just in case — resume time
        Time.timeScale = 1f;

        // Load your gameplay scene
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
