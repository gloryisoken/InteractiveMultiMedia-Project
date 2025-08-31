using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        // Only react if the player enters
        if (other.CompareTag("Player"))
        {
            // Load the next scene normally (replace current scene)
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
                Debug.Log("Portal triggered! Loading scene: " + sceneToLoad);
            }
            else
            {
                Debug.LogWarning("sceneToLoad is empty! Assign the scene name in the Inspector.");
            }
        }
    }
}
