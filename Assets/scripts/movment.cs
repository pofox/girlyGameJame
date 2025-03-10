using UnityEngine;

public class movment : MonoBehaviour
{
    // Movement speed in units per second
    [SerializeField] private float moveSpeed = 5f;
    
    // Reference to the Rigidbody2D component
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Get the Rigidbody2D component attached to this object
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input from horizontal (A/D or Left/Right arrows) and vertical (W/S or Up/Down arrows) axes
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0)
        {
            animator.SetBool("right", true);
            transform.localScale = new Vector3(Mathf.Sign(movement.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else animator.SetBool("right", false);

        if (movement.y > 0) animator.SetBool("up", true);
        else animator.SetBool("up", false);
        
        if (movement.y < 0) animator.SetBool("down", true);
        else animator.SetBool("down", false);
    }

    void FixedUpdate()
    {
        // Move the character using physics
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
