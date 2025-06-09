using UnityEngine;
using UnityEngine.SceneManagement;  // Needed for scene management

public class SceneChangeTrigger : MonoBehaviour
{
    // The name or build index of the scene you want to load
    public string sceneToLoad;

    // This method is called when another collider enters this object's trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding with this trigger is the player
        if (other.CompareTag("Player"))
        {
            // Load the new scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
