using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify the player movement script about collecting the coin
            other.GetComponent<PlayerMovement>().CollectCoin();
            Destroy(gameObject); // Destroy the coin when collected (you may want to play a sound or animation)
        }
    }
}
