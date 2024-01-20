using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

        void Start()
    {
        // Add click listeners to the buttons
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("SampleScene");
    }

   

    public void QuitGame()
    {
        // Quit the game (works in standalone builds)
        Application.Quit();
    }
}