using UnityEngine;

public class PlayerControl : MonoBehaviour
{

     public float moveSpeed;   
    [SerializeField] private float limitX;      


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //speed move
        float input = Input.GetAxis("Horizontal"); 
        Vector3 move = new Vector3(input * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(move);
        
        // limit
        float clampedX = Mathf.Clamp(transform.position.x, -limitX, limitX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
