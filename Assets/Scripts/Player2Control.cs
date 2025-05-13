using UnityEngine;
using static PlayerControl;

public class Player2Control : MonoBehaviour
{
    public float moveSpeed;
    
    [SerializeField] private float offsetX = 6f; 
    [SerializeField] private float limitX = 2f;
    public enum PlayerType { P1, P2 }
    public PlayerType playerType = PlayerType.P1;
    public Color defaultP1Color = Color.red;
    public Color defaultP2Color = Color.blue;
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

    void Update()
    {
        
        float input = Input.GetAxis("Horizontal2");
        Vector3 move = new Vector3(input * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(move);


        float clampedX = Mathf.Clamp(transform.position.x, offsetX - limitX, offsetX + limitX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}

