using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene("MainMenu");
    }
}
