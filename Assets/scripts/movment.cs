using UnityEngine;

public class movment : MonoBehaviour
{
    // Movement speed in units per second
    [SerializeField] private float moveSpeed = 5f;
    
    // Reference to the Rigidbody2D component
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Get the Rigidbody2D component attached to this object
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from horizontal (A/D or Left/Right arrows) and vertical (W/S or Up/Down arrows) axes
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Move the character using physics
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
