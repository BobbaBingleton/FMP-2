using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathObject : MonoBehaviour
{
    // Optional: Reference to the player GameObject if you want specific actions
    public GameObject player;

    // Called when another collider enters this object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object colliding with the DeathObject is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the Die method when the player steps on the death object
            Die();
        }
    }

    // Handle the player's death (you can modify this for custom death effects)
    private void Die()
    {
        // Option 1: Restart the current scene (you can change this to any custom behavior)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Option 2: Destroy the player if you want to simply remove them from the scene (use carefully)
        // Destroy(player);

        // Option 3: Call a death animation or event on the player (if you have one set up)
        // Example: player.GetComponent<PlayerController>().TriggerDeathAnimation();
    }
}
