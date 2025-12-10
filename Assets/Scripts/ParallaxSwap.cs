using UnityEngine;

public class ParallaxSwap : MonoBehaviour
{
    public GameObject defaultParallax;
    public GameObject outdoorParallax;

    private int nextSwapScore = 5;

    void Update()
    {
        int score = Mathf.FloorToInt(GameManager.instance.currentScore);

        if (score >= nextSwapScore)
        {
            defaultParallax.SetActive(!defaultParallax.activeSelf);
            outdoorParallax.SetActive(!outdoorParallax.activeSelf);

            nextSwapScore += 5;
        }
    }
}
