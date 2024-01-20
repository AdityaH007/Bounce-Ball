using UnityEngine;

public class Surface : MonoBehaviour
{
    public float bounceForce = 2f; // Adjust the bounce force as needed

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BounceOffSurface(collision.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void BounceOffSurface(Rigidbody rb)
    {
        // Apply a bounce force to the player's Rigidbody
        rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
    }
}
