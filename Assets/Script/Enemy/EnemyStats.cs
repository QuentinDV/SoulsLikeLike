using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int lvl ;
    public int health ;
    public int maxHealth ;
    public int damage ;
    public int defense ;
    public int xpReward ;
    public float speed = 1.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lvl = Random.Range(1, 10);
        health = lvl * 10;
        maxHealth = health;
        damage = lvl * 2;
        defense = lvl;
        xpReward = lvl * 10;
        
    }



}
