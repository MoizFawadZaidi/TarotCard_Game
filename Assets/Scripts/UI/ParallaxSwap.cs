using UnityEngine;

public class ParallaxSwap : MonoBehaviour
{
    public GameObject defaultParallax;
    public GameObject outdoorParallax;

    public CanvasGroup fadePanel;

    public int nextSwapScore;
    public int swapScore;
    private bool isFading = false;
    
    public float fadeSpeed;

    void Update()
    {
        int score = Mathf.FloorToInt(GameManager.instance.currentScore);

        if (score >= nextSwapScore && !isFading)
        {
            StartCoroutine(FadeAndSwap());
            nextSwapScore += swapScore;
        }
    }

    System.Collections.IEnumerator FadeAndSwap()
    {
        isFading = true;

        // Fade IN
        while (fadePanel.alpha < 1f)
        {
            fadePanel.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        
        defaultParallax.SetActive(!defaultParallax.activeSelf);
        outdoorParallax.SetActive(!outdoorParallax.activeSelf);

        // Fade OUT
        while (fadePanel.alpha > 0f)
        {
            fadePanel.alpha -= Time.deltaTime * fadeSpeed; 
            yield return null;
        }

        fadePanel.alpha = 0f;
        isFading = false;
    }
}

