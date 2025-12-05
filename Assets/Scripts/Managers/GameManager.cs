using global::UnityEngine;

public class GameManager : UnityEngine.MonoBehaviour
{
    #region Singlton

    public static global::GameManager instance;

    private void Awake()
    {
        if (GameManager.instance == null) GameManager.instance = this;

    }

    #endregion

    public float currentScore = 0f;

    public bool isPlaying = false;

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += UnityEngine.Time.deltaTime;
        }

        if (UnityEngine.Input.anyKeyDown)
        {
            isPlaying = true;
        }

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     currentScore += 5;
        // }
    }

    public void GameOver()
    {
        
        isPlaying = false;
    }


    public string PrettyScore()
    {
        return UnityEngine.Mathf.RoundToInt(currentScore).ToString();
    }
}
