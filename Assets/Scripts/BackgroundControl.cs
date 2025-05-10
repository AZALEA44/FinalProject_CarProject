using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class BackgroundControl : MonoBehaviour
{
    private BoxCollider colliderControl;
    private Rigidbody rb;

    private float lengthZ;

    [SerializeField] private float scrollSpeed = -5f; // Negative to move backward

    private void Start()
    {
        colliderControl = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();

        colliderControl.enabled = false;

        rb.useGravity = false;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;

        lengthZ = colliderControl.size.z * transform.localScale.z;
    }

    private void FixedUpdate()
    {
        // Scroll the background
        Vector3 moveDelta = new Vector3(0, 0, scrollSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + moveDelta);

        // If the object moves past -lengthZ, reset position forward
        if (transform.position.z < -lengthZ)
        {
            Vector3 resetPosition = transform.position + new Vector3(0, 0, lengthZ * 2f);
            rb.position = resetPosition; // use .position directly to avoid conflicts
        }
    }
}
