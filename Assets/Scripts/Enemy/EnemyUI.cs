using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUi : MonoBehaviour
{
    private Enemy enemy;
    public GameObject enemyUI;
    public Image healthBar;
    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyLevel;

    
    void Start()
    {
        enemy = GetComponent<Enemy>();
        UpdateHealthBar();
    }


    public void UpdateHealthBar()
    {
        enemyName.text = enemy.enemyName;
        enemyLevel.text = "Lvl. " + enemy.lvl;
        if (healthBar != null)
        {
            healthBar.transform.localScale = new Vector3((float)enemy.health / enemy.maxHealth, 1, 1);
        }
    }
}
