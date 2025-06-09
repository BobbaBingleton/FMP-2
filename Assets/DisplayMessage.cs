using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public GameObject messageText;    // Parent UI panel (e.g. WinnerPanel)
    public Text childText;            // Text (Legacy) component inside the panel
    public CanvasGroup canvasGroup;   // CanvasGroup component on the panel

    [Header("Fade Settings")]
    public float fadeDuration = 1f;

    private void Awake()
    {
        // Ensure message panel is hidden and fully transparent at start
        messageText.SetActive(false);
        canvasGroup.alpha = 0f;
    }

    /// <summary>
    /// Call this method to show the message text and fade the panel in.
    /// </summary>
    /// <param name="message">Message string to display</param>
    public void ShowMessage(string message )
    {
        if (message != "") 
        {
            childText.text = message;
        }
        
        // Set the message text
        messageText.SetActive(true);   // Activate the panel
        canvasGroup.alpha = 0f;        // Start from transparent
        StartCoroutine(Fade(0f, 1f, fadeDuration)); // Fade in
    }

    /// <summary>
    /// Coroutine to fade the canvasGroup alpha smoothly.
    /// </summary>
    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            yield return null;
        }
        canvasGroup.alpha = endAlpha;
    }
}
