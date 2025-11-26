using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneUI : MonoBehaviour
{   


    public Text finalScoreText;
    

    void Start()
    {
        
        float saved = PlayerPrefs.GetFloat("LastScoreFloat", 0f);

        
        int display = Mathf.RoundToInt(saved);
        finalScoreText.text = "POINTS: " + display.ToString();
    }

    public void Restart()
    {
        
        SceneManager.LoadScene("GameScene");
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