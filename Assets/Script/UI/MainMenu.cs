using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel; 
    public GameObject player;      
    public Camera menuCamera;      

    void Start()
    {
        player.SetActive(false);  
        menuCamera.gameObject.SetActive(true); 
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false); 
        menuCamera.gameObject.SetActive(false); 
        player.SetActive(true); 
        Time.timeScale = 1f; 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
