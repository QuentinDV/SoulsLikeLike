using UnityEngine;

public class Player : MonoBehaviour
{
    public int lvl = 1;

    public int health = 100;
    public int maxHealth = 100;

    public int xp = 0;

    public int attack = 10;

    public DeathMenu deathMenu; // Référence à DeathMenu

  

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Time.timeScale = 0;
            deathMenu.DeathGame(); 
        }

        // reculer le joueur
        GetComponent<Rigidbody>().linearVelocity = -transform.forward * 3;
    }

    public void GainXp(int xp)
    {
        this.xp += xp;

        if (this.xp >= 100+ lvl*50)
        {
            this.xp -= 100+ lvl*50;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        lvl++;
        maxHealth += 50;
        health = maxHealth;
        attack += 5;
    }
}
