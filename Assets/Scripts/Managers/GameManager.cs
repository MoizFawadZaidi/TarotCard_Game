using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject controlsParent;
    [SerializeField] AudioSource backgroundMusic;
    
    #region Singlton

    public static GameManager instance;

    private void Start()
    {
        //SoundFXManager.instance.PlaySoundFXClip(backgroundMusic, transform, 0.05f);
        //Instantiate(backgroundMusic);
        backgroundMusic.loop =  true;
        backgroundMusic.ignoreListenerPause = true;
        //backgroundMusic.Play();
    }

    private void Awake()
    {
        if (instance == null) instance = this;
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
