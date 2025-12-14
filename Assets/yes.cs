using UnityEngine;

public class PlayerMovement2_5D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Rigidbody rb;

    private bool isGrounded;

    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        // Move only on X
        Vector3 movement = new Vector3(moveX * moveSpeed, rb.linearVelocity.y, 0);
        rb.linearVelocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}

