using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingsPanel;

    void Start()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // BUTTON: Play
    public void PlayGame()
    {
        Debug.Log("Play button clicked");

        SceneManager.LoadScene("GameScene");
    }

    // BUTTON: Open Settings
    public void OpenSettings()
    {
        Debug.Log("Settings opened");

        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    // BUTTON: Close Settings
    public void CloseSettings()
    {
        Debug.Log("Settings closed");

        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    // BUTTON: Quit Game
    public void QuitGame()
    {
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}