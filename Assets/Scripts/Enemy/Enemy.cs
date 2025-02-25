using UnityEngine;
using UnityEngine.AI;

public class Enemy: MonoBehaviour
{
    public string enemyName;
    public int lvl ;
    public int lvlmin ;
    public int lvlmax ;
    public int health ;
    public int maxHealth ;
    public int damage ;
    public int xpReward ;
    public float speed = 1.5f;
    public bool isBoss = false;

    private EnemyUi enemyUi;
    
    public GameObject Player;
    public WinMenu WInMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lvl = Random.Range(lvlmin, lvlmax);
        health = lvl * 10;
        maxHealth = health;
        damage = lvl * 2;
        xpReward = lvl * 10;

        enemyUi = GetComponent<EnemyUi>();
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            enemyUi.UpdateHealthBar();
            GetComponent<NavMeshAgent>().speed = 0;
            GetComponent<Animator>().SetBool("isDead", true);
            Player.GetComponent<Player>().LevelUp();

            if (isBoss)
            {
                WInMenu.WinGame();
            }
             else {
            Destroy(this.gameObject,1.25f);
            Player.GetComponent<Player>().GainXp(xpReward);
             }
        }
        else
        {
            enemyUi.UpdateHealthBar();
        }

        // fais reculer l'ennemi
        GetComponent<NavMeshAgent>().velocity = -transform.forward * 3;
    }

}
