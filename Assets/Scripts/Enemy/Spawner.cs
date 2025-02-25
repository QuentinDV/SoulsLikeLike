using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Référence à l'objet ennemi à spawner
    public Player player; // Référence au joueur
    public int lvlmin ;
    public int lvlmax ;
    public Transform[] spawnPoints; // Tableau des points de spawn
    public float spawnInterval = 10f; // Intervalle de spawn en secondes
    private float timer;

    void Start()
    {
        timer = spawnInterval; // Initialise le timer pour attendre le prochain spawn
    }

    void Update()
    {
        timer -= Time.deltaTime; // Réduit le timer avec le temps qui passe

        if (timer <= 0f)
        {
            TrySpawnEnemy(); // Essaie de faire apparaître un ennemi
            timer = spawnInterval; // Réinitialise le timer
        }
    }

    void TrySpawnEnemy()
    {
        if (Random.Range(1, 6) == 1) 
        {
            // Sélectionne un point de spawn aléatoire parmi les trois points
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Spawne l'ennemi au point sélectionné
            GameObject spawnedEnemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
            
            // Donne la référence du joueur à l'ennemi
            spawnedEnemy.GetComponent<Enemy>().Player = player.gameObject;
            spawnedEnemy.GetComponent<EnemyMovement>().Player = player.gameObject;

            // Donne un niveau aléatoire à l'ennemi
            spawnedEnemy.GetComponent<Enemy>().lvlmin = lvlmin;
            spawnedEnemy.GetComponent<Enemy>().lvlmax = lvlmax;

        }
    }
}
