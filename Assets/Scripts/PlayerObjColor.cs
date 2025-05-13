using UnityEngine;

public class PlayerObjColor : MonoBehaviour
{
    public enum PlayerType { P1, P2 }

    public PlayerType playerType = PlayerType.P1;

    // สี default สำหรับกรณีไม่มี Manager
    public Color defaultP1Color = Color.red;
    public Color defaultP2Color = Color.blue;

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        // ลองดึงสีจาก Manager ถ้ามี
        if (Setting.Instance != null)
        {
            rend.material.color = (playerType == PlayerType.P1) ?
                Setting.Instance.GetP1Color() :
                Setting.Instance.GetP2Color();
        }
        else
        {
            // ถ้าไม่มี Manager, ใช้สี default
            rend.material.color = (playerType == PlayerType.P1) ?
                defaultP1Color : defaultP2Color;
        }
    }
}
