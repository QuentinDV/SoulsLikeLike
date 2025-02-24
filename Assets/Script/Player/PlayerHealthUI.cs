using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    private Player player; // Référence au Player
    public GameObject healtCanvas; // Référence au canvas de la barre de vie
    public GameObject healthBar; // Référence à la barre de vie

    void Start()
    {
        player = GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {if (Time.timeScale == 0) // Vérifie si le jeu est en pause
        {
            healtCanvas.SetActive(false);
        }
        else
        {
            healtCanvas.SetActive(true);
            healthBar.transform.localScale = new Vector3((float)player.health / player.maxHealth, 1, 1);
        }
        
    }
}
