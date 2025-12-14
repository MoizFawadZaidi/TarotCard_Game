using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToMenu : MonoBehaviour
{
    private bool canEscape = true;
    
    void Update()
    {
        if (Time.timeScale != 1)
        {
            canEscape = false;
        }
        else
        {
            canEscape = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && canEscape)
        {
            SceneManager.LoadScene(0); // 0 = MainMenu in Build Settings
        }
    }
}
