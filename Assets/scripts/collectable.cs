using UnityEngine;

public class collectable : MonoBehaviour
{
    //[SerializeField] private float rotationSpeed = 180f; // Rotation speed in degrees per second
    [SerializeField] private int scoreValue = 1; // How many points this collectable is worth

    private void Update()
    {
        // Rotate the collectable around the Y axis
        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered");
        // Check if the object that entered the trigger is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add score through the GameManager
            GameManager.Instance.AddScore(scoreValue);

            // Destroy the collectable
            Destroy(gameObject);
        }
    }
}