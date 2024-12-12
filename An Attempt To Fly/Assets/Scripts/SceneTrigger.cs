using UnityEngine;
using UnityEngine.SceneManagement; // Needed for loading scenes

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // The name of the scene you want to load

    // This method is called when another object with a collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        // This could be done by checking a tag or a component.
        // For example, if your player is tagged "Player":
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log(sceneToLoad);
        }
    }
}
