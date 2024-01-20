using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust the rotation speed as needed

    void Update()
    {
        // Rotate the coin around the x-axis
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
