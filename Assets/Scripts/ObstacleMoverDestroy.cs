using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class ObstacleMoverDestroy : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float scrollSpeed = -5f; // How fast the obstacle moves backward
    [SerializeField] private float destroyZ = -30f;   // Z position at which the obstacle is destroyed

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
    }

    private void FixedUpdate()
    {
        // Move backward
        Vector3 moveDelta = new Vector3(0, 0, scrollSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + moveDelta);

        // Destroy if out of screen (behind the player/camera)
        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
