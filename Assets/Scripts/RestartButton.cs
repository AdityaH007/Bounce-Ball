using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public Button restartButton;
    public Button Menu; // Now public, you can assign it in the Unity Editor

    private void Start()
    {
        // Check if restartButton is not null before adding the listener
        if (restartButton != null)
        {
            // Add a listener to the button to call the RestartGame method when clicked
            restartButton.onClick.AddListener(RestartGame);
        }
        else
        {
            Debug.LogError("Button component not assigned in the Unity Editor.");
        }


        Menu.onClick.AddListener(Endgame);
    }

    private void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Endgame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
