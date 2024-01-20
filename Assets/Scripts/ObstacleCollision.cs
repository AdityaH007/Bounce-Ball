using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Notify the player movement script about the collision
            collision.gameObject.GetComponent<PlayerMovement>().PauseGame();
        }
    }
}
