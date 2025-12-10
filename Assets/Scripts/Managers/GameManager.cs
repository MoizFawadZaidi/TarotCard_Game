using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject controlsParent;
    public AudioSource backgroundMusic;
    
    #region Singlton

    public static GameManager instance;
    
    
    private void Awake()
    {
        if (instance == null) instance = this;
        
        backgroundMusic.playOnAwake = false;
        backgroundMusic.Stop();
        backgroundMusic.volume = 0.05f;
        backgroundMusic.loop =  true;
        backgroundMusic.ignoreListenerPause = true;
    }
    
    private void Start()
    {
        backgroundMusic.Play();
    }

    #endregion

    public float currentScore = 0f;

    public bool isPlaying = false;

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
            controlsParent.SetActive(false);
        }

        if (Input.anyKeyDown)
        {
            isPlaying = true;
        }
    }

    public void GameOver()
    {
        isPlaying = false;
    }


    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
