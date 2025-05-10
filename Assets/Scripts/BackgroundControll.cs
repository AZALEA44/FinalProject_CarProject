using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class BackgroundControll : MonoBehaviour
{
    private BoxCollider colliderControll;
    private Rigidbody rb;

    private float lengthZ;

    [SerializeField] private float scrollSpeed ; 

    private void Start()
    {
        colliderControll = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();

        // ปิด collider ถ้าไม่ใช้ชน
        colliderControll.enabled = false;

        // ตั้งค่า Rigidbody
        rb.useGravity = false;
        rb.isKinematic = false; 
        rb.constraints = RigidbodyConstraints.FreezeRotation; 

        // กำหนดความยาวตามแกน Z
        lengthZ = colliderControll.size.z * transform.localScale.z;

        // เคลื่อนที่ด้วยความเร็วคงที่ในแนว Z
        rb.linearVelocity = new Vector3(0, 0, scrollSpeed);
    }

    private void FixedUpdate()
    {
        // วัดว่า object เลื่อนไปไกลเกินจุด reset หรือยัง
        if (transform.position.z < -lengthZ)
        {
            Vector3 resetOffset = new Vector3(0, 0, lengthZ * 2f);
            rb.MovePosition(rb.position + resetOffset);
        }
    }
}
