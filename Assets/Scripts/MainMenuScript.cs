using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject creditsUI;

    public void StartGame()
    {
        SceneManager.LoadScene(1); // loads your GameScene
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
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
