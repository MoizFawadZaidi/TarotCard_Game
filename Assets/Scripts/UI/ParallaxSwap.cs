using UnityEngine;

public class ParallaxSwap : MonoBehaviour
{
    public GameObject defaultParallax;
    public GameObject outdoorParallax;

    public CanvasGroup fadePanel;  

    private int nextSwapScore = 5;
    private bool isFading = false;

    void Update()
    {
        int score = Mathf.FloorToInt(GameManager.instance.currentScore);

        if (score >= nextSwapScore && !isFading)
        {
            StartCoroutine(FadeAndSwap());
            nextSwapScore += 5;
        }
    }

    System.Collections.IEnumerator FadeAndSwap()
    {
        isFading = true;

        // Fade IN
        while (fadePanel.alpha < 1f)
        {
            fadePanel.alpha += Time.deltaTime * 1.5f;
            yield return null;
        }

        
        defaultParallax.SetActive(!defaultParallax.activeSelf);
        outdoorParallax.SetActive(!outdoorParallax.activeSelf);

        // Fade OUT
        while (fadePanel.alpha > 0f)
        {
            fadePanel.alpha -= Time.deltaTime * 1.5f; 
            yield return null;
        }

        fadePanel.alpha = 0f;
        isFading = false;
    }
}

