using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    // Hook these up in Inspector if you want (not required)
    // public GameObject deathScreen;

    // Called by the Restart button
    public void Restart()
    {
        Time.timeScale = 1f; // resume time in case it was paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Called by the Quit button
    public void Quit()
    {
#if UNITY_EDITOR
        // Stop play mode in the editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
