using UnityEngine;

public class Boss : MonoBehaviour
{
    public Enemy enemy;


    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
