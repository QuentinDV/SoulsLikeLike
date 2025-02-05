using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed;
    public float JumpHeight;
    public float RotationSpeed;

    private Animator animator; // Pour contrôler les animations

    void Start()
    {
        animator = GetComponent<Animator>(); // Récupère le composant Animator
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Input.mousePositionDelta.x * RotationSpeed/10, 0));

        Vector3 CurrentSpeed = 
        transform.forward * PlayerSpeed * Input.GetAxis("Vertical")+
        transform.right * PlayerSpeed * Input.GetAxis("Horizontal");

        CurrentSpeed.y = GetComponent<Rigidbody>().linearVelocity.y;
        
        GetComponent<Rigidbody>().linearVelocity = CurrentSpeed;

        // Animation : gérer la course
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isRunning", true); // Le joueur se déplace, on active la course
        }
        else
        {
            animator.SetBool("isRunning", false); // Le joueur ne se déplace pas, on désactive la course
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(GetComponent<Rigidbody>().linearVelocity.y) < 0.01f)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,JumpHeight,0));
        }
    }
}
