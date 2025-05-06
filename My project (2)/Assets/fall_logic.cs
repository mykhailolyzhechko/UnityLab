using UnityEngine;

public class SphereDropper : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.isKinematic = false; // Enable gravity and allow the sphere to fall
        }
    }
}
