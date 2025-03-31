using UnityEngine;
using UnityEngine.UI; // Needed for UI messages

public class ParachuteJump : MonoBehaviour
{
    public float fallSpeed = 0f;
    public float gravity = -9.81f;
    public float parachuteFallSpeed = -3f; // Reduced fall speed after parachute opens
    public bool parachuteOpened = false;
    public Text messageText; // UI text to show messages

    private Rigidbody rb;
    private bool hasLanded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // We will control gravity manually
        messageText.text = ""; // Clear UI text at start
    }

    void Update()
    {
        if (!hasLanded)
        {
            // Apply gravity before parachute opens
            if (!parachuteOpened)
            {
                fallSpeed += gravity * Time.deltaTime;
            }

            // Open parachute when pressing "Space"
            if (Input.GetKeyDown(KeyCode.Space) && !parachuteOpened)
            {
                parachuteOpened = true;
                fallSpeed = parachuteFallSpeed; // Reduce falling speed
                Debug.Log("Parachute opened!");
            }

            // Apply downward movement
            rb.velocity = new Vector3(0, fallSpeed, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasLanded = true;
            rb.velocity = Vector3.zero;

            if (parachuteOpened)
            {
                messageText.text = "Safe landing! 🎉";
                Debug.Log("Safe landing!");
            }
            else
            {
                messageText.text = "Failed! You crashed! 💀";
                Debug.Log("You crashed!");
            }
        }
    }
}