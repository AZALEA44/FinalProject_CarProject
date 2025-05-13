using UnityEngine;

public class Player2Control : MonoBehaviour
{
    public float moveSpeed;
    
    [SerializeField] private float offsetX = 6f; 
    [SerializeField] private float limitX = 2f;

    void Start()
    {
        
        
    }

    void Update()
    {
        
        float input = Input.GetAxis("Horizontal2");
        Vector3 move = new Vector3(input * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(move);


        float clampedX = Mathf.Clamp(transform.position.x, offsetX - limitX, offsetX + limitX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}

