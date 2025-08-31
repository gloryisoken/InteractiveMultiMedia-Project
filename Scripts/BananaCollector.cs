using UnityEngine;

public class BananaCollector : MonoBehaviour
{
    // Keeps track of how many bananas the player has collected
    private static int bananasCollected = 0; // static so all bananas share the same count

    // This function is called when another collider enters this trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Increase the collected banana count
            bananasCollected++;

            // Remove this banana from the scene
            Destroy(gameObject);

            // Log the total bananas collected so far
            Debug.Log("Bananas collected: " + bananasCollected);
        }
    }
}
