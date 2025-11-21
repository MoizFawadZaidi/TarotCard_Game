using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneUI : MonoBehaviour
{
    public Text finalScoreText;

    void Start()
    {
        // Display the score that was stored before death
        finalScoreText.text = "Score: " + PlayerPrefs.GetInt("PrettyScore", 0);
    }

    public void Restart()
    {
        
        SceneManager.LoadScene("TestScene");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}