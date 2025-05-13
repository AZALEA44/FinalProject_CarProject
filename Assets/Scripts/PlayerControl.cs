using UnityEngine;

public class PlayerControl : MonoBehaviour
{

     public float moveSpeed;   
    [SerializeField] private float limitX;
    public enum PlayerType { P1, P2 }
    public PlayerType playerType = PlayerType.P1;
    public Color defaultP1Color = Color.red;
    public Color defaultP2Color = Color.blue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (Setting.Instance != null)
        {
            rend.material.color = (playerType == PlayerType.P1) ?
                Setting.Instance.GetP1Color() :
                Setting.Instance.GetP2Color();
        }
        else
        {
            rend.material.color = (playerType == PlayerType.P1) ?
                defaultP1Color : defaultP2Color;
        }
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
