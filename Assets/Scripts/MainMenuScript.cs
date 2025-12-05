using global::UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : UnityEngine.MonoBehaviour
{
    public UnityEngine.GameObject mainMenuUI;
    public UnityEngine.GameObject creditsUI;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); // loads your GameScene
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
        UnityEngine.Debug.Log("Quit Game");
    }

    public void ShowCredits()
    {
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void BackToMenu()
    {
        creditsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
