using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player;
    private Enemy enemy;
    public float detectionRange = 10f;
    public float stoppingDistance = 0.75f;
    public float attackRange = 1.25f; // Distance d'attaque
    public float attackCooldown = 2f; // Temps entre chaque attaque
    private float attackTimer;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        GetComponent<NavMeshAgent>().speed = enemy.speed;
        attackTimer = attackCooldown; // Initialise le timer d'attaque
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceToPlayer <= detectionRange) // Si le joueur est à portée
        {
            GetComponent<NavMeshAgent>().SetDestination(Player.transform.position); // L'ennemi se dirige vers le joueur
            GetComponent<Animator>().SetBool("isWalking", true); // Déclenche l'animation d'attaque

            if (distanceToPlayer <= stoppingDistance) // Si trop proche, stoppe l’ennemi
            {
                GetComponent<NavMeshAgent>().isStopped = true;
            }
            else
            {
                GetComponent<NavMeshAgent>().isStopped = false;
            }

            if (distanceToPlayer <= attackRange) // Si dans la distance d'attaque
            {
                attackTimer -= Time.deltaTime; // Réduit le temps avant la prochaine attaque

                if (attackTimer <= 0f) // Si l'ennemi peut attaquer
                {
                    AttackPlayer(); // Appelle la fonction d'attaque
                    attackTimer = attackCooldown; // Réinitialise le timer
                }
            }
        }
        else
        {
            GetComponent<NavMeshAgent>().isStopped = true; // L'ennemi ne bouge pas si le joueur est trop loin
            GetComponent<Animator>().SetBool("isWalking", false); // Déclenche l'animation d'attaque
        }
    }

    // Fonction d'attaque
    void AttackPlayer()
    {
        if (Player != null)
        {
            Player.GetComponent<Player>().TakeDamage(enemy.damage); // Inflige des dégâts au joueur
        }
    }

    void OnTriggerEnter()
    {
        GetComponent<Animator>().SetBool("isNear", true); // Déclenche l'animation d'attaque
    }

    void OnTriggerExit()
    {
        GetComponent<Animator>().SetBool("isNear", false); // Arrête l'animation d'attaque
    }
}
