using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject controlsParent;
    
    #region Singlton

    public static GameManager instance;

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
