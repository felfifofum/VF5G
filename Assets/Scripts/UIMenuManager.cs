using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class UIMenuManager : MonoBehaviour
{
    public Button restartButton; 
    public Button quitButton; 

    void Start()
    {
        restartButton.onClick.AddListener(() => RestartGame());
        quitButton.onClick.AddListener(() => QuitGame());

        restartButton.enabled = false;
        quitButton.enabled = false;
    }

    public void ShowGameOverButtons()
    {
        restartButton.enabled = true;
        quitButton.enabled = true;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit(); // Quits the application (works in builds, not in the editor)
    }
}