using UnityEngine;

public class BossZone : MonoBehaviour
{
    public GameObject PlayerCamera;
    public GameObject BossCamera; 
    private float _timer = 0;
    private bool isActivated = false;

    public Transform StartPosition, EndPosition;
    public float transitionTime = 4f; // Temps total du déplacement

    private PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            player = other.GetComponent<PlayerController>();
            player.PlayerSpeed = 0;
            
            PlayerCamera.SetActive(false);
            BossCamera.SetActive(true);
            BossCamera.transform.position = StartPosition.position;
            
            isActivated = true;
            _timer = 0;
        }
    }

    private void Update()
    {
        if (isActivated)
        {
            _timer += Time.deltaTime;
            float progress = Mathf.Clamp01(_timer / transitionTime);
            BossCamera.transform.position = Vector3.Lerp(StartPosition.position, EndPosition.position, progress);

            if (progress >= 1f)
            {
                isActivated = false;
                Invoke(nameof(ResetState), 2f); // Attends 2 secondes avant de tout réinitialiser
            }
        }
    }

    private void ResetState()
    {
        BossCamera.SetActive(false);
        PlayerCamera.SetActive(true);
        player.PlayerSpeed = 5; // Remet la vitesse du joueur à la normale (à ajuster si besoin)
    }
}
