using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    public Player player; // Référence au Player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(player.attack);
        }
    }

    public void ActivateHitbox()
    {
        gameObject.SetActive(true);
        Invoke(nameof(DeactivateHitbox), 0.2f); // Désactive après 0.2s
    }

    private void DeactivateHitbox()
    {
        gameObject.SetActive(false);
    }
}
