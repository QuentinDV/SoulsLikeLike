using UnityEngine;

public class DeathZone : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Player player = other.GetComponent<Player>();
            player.health = 0;
        }
    }
}
