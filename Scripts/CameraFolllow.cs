using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Drag your Player cube here in the Inspector
    public Vector3 offset = new Vector3(0, 5, -10); // Camera's position relative to the player
    public float smoothSpeed = 0.125f; // How smoothly the camera follows

    void LateUpdate()
    {
        if (player == null) return; // Make sure we have a player assigned

        // Desired camera position = player's position + offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move camera from current position to desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply the smooth position
        transform.position = smoothedPosition;

        // Optional: Make camera always look at the player
        transform.LookAt(player);
    }
}
