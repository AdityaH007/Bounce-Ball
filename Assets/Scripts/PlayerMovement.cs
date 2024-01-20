using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float jumpForce = 5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody playerRigidbody;
    private bool isGamePaused = false;
    public GameObject endScreenCanvas; // Reference to the end screen canvas
    private Text pointsText; // Reference to the UI Text for displaying points
    private int points = 0;

    private void Start()
    {
        endScreenCanvas.SetActive(false);
        playerRigidbody = GetComponent<Rigidbody>();
        StartCoroutine(StartDelayedMovement(0f));

        // Find the UI Text component
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        UpdatePointsDisplay();
    }

    private IEnumerator StartDelayedMovement(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(ContinuousForwardMovement());
    }

    private IEnumerator ContinuousForwardMovement()
    {
        while (!isGamePaused)
        {
            // Move the player forward continuously
            Vector3 forwardMovement = transform.forward * forwardSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(playerRigidbody.position + forwardMovement);
            yield return null;
        }
    }

    private void Update()
    {
        // Check for player input (tap or key press)
        if (!isGamePaused && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        ApplyGravity();
    }

    private void Jump()
    {
        // Reset vertical velocity and apply jump force
        playerRigidbody.velocity = new Vector3(0, 0, 0);
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void ApplyGravity()
    {
        if (playerRigidbody.velocity.y < 0)
        {
            Vector3 fallGravity = new Vector3(0, -fallMultiplier, 0);
            playerRigidbody.AddForce(fallGravity);
        }
        else if (playerRigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            Vector3 lowJumpGravity = new Vector3(0, -lowJumpMultiplier, 0);
            playerRigidbody.AddForce(lowJumpGravity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Collision with obstacle detected
            PauseGame();
        }
    }

    public void PauseGame()
    {
        // Stop continuous forward movement
        isGamePaused = true;
        StopCoroutine(ContinuousForwardMovement());

        // Display end screen canvas
        endScreenCanvas.SetActive(true);
    }

    public void CollectCoin()
    {
        // Increment points when a coin is collected
        points += 10; // Adjust the points as needed
        UpdatePointsDisplay();
    }

    private void UpdatePointsDisplay()
    {
        // Update the UI Text to display the current points
        pointsText.text = "Points: " + points;
    }
}
