using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    private Player player; // Référence au Player
    public GameObject healthBar; // Référence à la barre de vie

    void Start()
    {
        player = GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3((float)player.health / player.maxHealth, 1, 1);
        
    }
}
