using global::UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToMenu : UnityEngine.MonoBehaviour
{
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); // 0 = MainMenu in Build Settings
        }
    }
}
