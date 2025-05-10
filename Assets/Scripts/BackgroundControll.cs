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

        // �Դ collider �������骹
        colliderControll.enabled = false;

        // ��駤�� Rigidbody
        rb.useGravity = false;
        rb.isKinematic = false; 
        rb.constraints = RigidbodyConstraints.FreezeRotation; 

        // ��˹�������ǵ��᡹ Z
        lengthZ = colliderControll.size.z * transform.localScale.z;

        // ����͹�����¤������Ǥ������� Z
        rb.linearVelocity = new Vector3(0, 0, scrollSpeed);
    }

    private void FixedUpdate()
    {
        // �Ѵ��� object ����͹����Թ�ش reset �����ѧ
        if (transform.position.z < -lengthZ)
        {
            Vector3 resetOffset = new Vector3(0, 0, lengthZ * 2f);
            rb.MovePosition(rb.position + resetOffset);
        }
    }
}
