using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed;
    public float JumpHeight;
    public float RotationSpeed;

    private Animator animator; 
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.timeScale != 0) { 
            transform.Rotate(new Vector3(0, Input.mousePositionDelta.x * RotationSpeed/10, 0));

            Vector3 CurrentSpeed = 
            transform.forward * PlayerSpeed * Input.GetAxis("Vertical")+
            transform.right * PlayerSpeed * Input.GetAxis("Horizontal");

            CurrentSpeed.y = GetComponent<Rigidbody>().linearVelocity.y;
            
            GetComponent<Rigidbody>().linearVelocity = CurrentSpeed;

            // Animation : gérer la course
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) {
                animator.SetBool("isWalking", true); 
            }
            else {
                animator.SetBool("isWalking", false); 
            }

            // Vérification si le joueur est au sol avec un Raycast
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.4f);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                GetComponent<Rigidbody>().AddForce(new Vector3(0,JumpHeight,0));
            }
        }
    }

}
