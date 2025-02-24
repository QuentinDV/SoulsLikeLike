using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private EnemyStats enemyStats;

    public GameObject Player;

    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        
        GetComponent<NavMeshAgent>().speed = enemyStats.speed;

    }

    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
    }

    public void TakeDamage(int damage)
    {
        
        if (enemyStats == null) return; // Empêche le crash si enemyStats est null

        enemyStats.health -= damage;

        if (enemyStats.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
