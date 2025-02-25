using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    private Player player; 
    public GameObject playerUI; 
    public GameObject healthBar; 
    public TextMeshProUGUI lvl;

    void Start()
    {
        player = GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) 
        {
            playerUI.SetActive(false);
        }
        else
        {
            playerUI.SetActive(true);
            healthBar.transform.localScale = new Vector3((float)player.health / player.maxHealth, 1, 1);
            UpdateLvl();
        }
    
    }
    

    public void UpdateLvl()
    {
        lvl.text = "Lvl. " + player.lvl + " | " + player.xp + "/" + (100 + player.lvl * 50);
    }
}
