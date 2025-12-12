using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject creditsUI;

    [SerializeField] private AudioClip clickSoundClip;

    public void StartGame()
    {
        SoundFXManager.instance.PlaySoundFXClip(clickSoundClip, transform, 0.1f);
        SceneManager.LoadScene(1); // loads your GameScene
    }

    public void QuitGame()
    {
        SoundFXManager.instance.PlaySoundFXClip(clickSoundClip, transform, 0.1f);
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void ShowCredits()
    {
        SoundFXManager.instance.PlaySoundFXClip(clickSoundClip, transform, 0.1f);
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void BackToMenu()
    {
        SoundFXManager.instance.PlaySoundFXClip(clickSoundClip, transform, 0.1f);
        creditsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
