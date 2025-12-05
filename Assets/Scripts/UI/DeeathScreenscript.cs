using global::UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneUI : UnityEngine.MonoBehaviour
{   


    public UnityEngine.UI.Text finalScoreText;
    

    void Start()
    {
        
        float saved = UnityEngine.PlayerPrefs.GetFloat("LastScoreFloat", 0f);

        
        int display = UnityEngine.Mathf.RoundToInt(saved);
        finalScoreText.text = "POINTS: " + display.ToString();
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
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