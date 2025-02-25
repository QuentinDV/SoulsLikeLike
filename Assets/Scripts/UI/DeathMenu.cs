using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuPanel;

    public void DeathGame()
    {
        deathMenuPanel.SetActive(true);
        Time.timeScale = 0f; // Stoppe le temps
    }

    public void RestartGame()
    {
        deathMenuPanel.SetActive(false);
        Time.timeScale = 1f; // Reprend le temps
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène actuelle
    }


    public void QuitGame()
    {
        Application.Quit();
    }
    
}
