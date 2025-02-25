using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenuPanel;

    public void WinGame()
    {
        winMenuPanel.SetActive(true);
        Time.timeScale = 0f; // Stoppe le temps
    }

    public void RestartGame()
    {
        winMenuPanel.SetActive(false);
        Time.timeScale = 1f; // Reprend le temps
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène actuelle
    }


    public void QuitGame()
    {
        Application.Quit();
    }
    
}
