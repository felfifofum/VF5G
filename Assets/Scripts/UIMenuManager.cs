using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class UIMenuManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public Button restartButton; 
    public Button quitButton; 

  public UIMenuManager uiMenuManager;

    void Start()
    {
        // Add listeners to buttons
        restartButton.onClick.AddListener(() => RestartGame());
        quitButton.onClick.AddListener(() => QuitGame());

        gameOverMenu.SetActive(false); 
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true); 
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit(); 
    }
}