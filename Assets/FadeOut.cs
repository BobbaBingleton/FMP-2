using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FadeOut : MonoBehaviour
{

    // Start is called before the first frame update
    public CanvasGroup canvasGroup;  // Reference to the CanvasGroup
    public float fadeDuration = 2f;  // Duration of the fade
    public float delayDuration = 2f; // Delay before starting the fade (in seconds)


    // Start is called before the first frame update
    void Start()
    {
        // If no CanvasGroup is assigned, try to find it on this GameObject
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();

        }
        FadeOutCanvas();
    }

    // Call this function to start the fade-out
    public void FadeOutCanvas()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    public void FadeInCanvas()
    {
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {

        // Wait for the specified delay before starting the fade
        yield return new WaitForSeconds(delayDuration);


        float startAlpha = canvasGroup.alpha;  // Initial alpha value
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            // Smoothly interpolate the alpha value over time
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha is set to 0 at the end
        canvasGroup.alpha = 0f;

        // Optionally, deactivate the GameObject after the fade-out completes
        //gameObject.SetActive(false);

    }

    private IEnumerator FadeInCoroutine()
    {
        // Wait for the specified delay before starting the fade
        yield return new WaitForSeconds(delayDuration);

        float startAlpha = canvasGroup.alpha;  // Initial alpha value (usually 0 for fade-in)
        float timeElapsed = 0f;

        // Fade in the canvas over time
        while (timeElapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha is set to 1 at the end
        canvasGroup.alpha = 1f;

        // Optionally, you can activate the GameObject after fading in
        gameObject.SetActive(true);  // Ensure the GameObject containing the CanvasGroup is active
    }
}
