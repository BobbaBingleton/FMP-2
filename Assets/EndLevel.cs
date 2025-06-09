using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public string nextSceneName;
    public DisplayMessage displayMessage;
    public FadeOut fadeOut;
    public string showMessage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Freeze the player
            FreezePlayer(other.gameObject);

            // Display win message
            displayMessage.ShowMessage(showMessage);

            fadeOut.FadeInCanvas();

            // Delay for visual effect (optional)
            Invoke("LoadNextLevel", 4f);
        }
    }

    private void FreezePlayer(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        // If your player has a movement script, disable it here:
        var movementScript = player.GetComponent<PlayerMovement>();
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
