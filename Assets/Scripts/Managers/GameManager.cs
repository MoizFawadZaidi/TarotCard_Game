using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isPlaying = true;
        }
    }

    public void GameOver()
    {
        currentScore = 0f;
        isPlaying = false;
    }


    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
