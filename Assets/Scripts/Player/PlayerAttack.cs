using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator; 
    public MeleeHitbox meleeHitbox; // Référence à la hitbox

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Clic gauche pour attaquer
        {
            animator.SetTrigger("Attack");
        }
    }

    // Cette fonction sera appelée par l'Animation Event
    public void TriggerHitbox()
    {
        if (meleeHitbox != null)
        {
            meleeHitbox.ActivateHitbox();
        }
    }
}
