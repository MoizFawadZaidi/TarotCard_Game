using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneUI : MonoBehaviour
{
    [SerializeField] private AudioClip clickSoundClip;

    public Text finalScoreText;
    

    void Start()
    {
        
        float saved = PlayerPrefs.GetFloat("LastScoreFloat", 0f);

        
        int display = Mathf.RoundToInt(saved);
        finalScoreText.text = display.ToString();
    }

    public void Restart()
    {
        SoundFXManager.instance.PlaySoundFXClip(clickSoundClip, transform, 0.1f);
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        SoundFXManager.instance.PlaySoundFXClip(clickSoundClip, transform, 0.1f);
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}