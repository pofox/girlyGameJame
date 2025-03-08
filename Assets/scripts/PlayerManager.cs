using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    private GameObject currentlyControlled;
    
    // Reference to player movement scripts - replace 'PlayerMovement' with your movement script name
    private movment player1Movement;
    private movment player2Movement;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Get references to player movement scripts
        player1Movement = player1.GetComponent<movment>();
        player2Movement = player2.GetComponent<movment>();

        // Set player1 as default controlled player
        currentlyControlled = player1;
        player2Movement.enabled = false; // Disable movement on player2
    }

    public void OnSwitchPlayer(InputValue value)
    {
        if (value.isPressed)
        {
            // Switch between players
            if (currentlyControlled == player1)
            {
                player1Movement.enabled = false;
                player2Movement.enabled = true;
                currentlyControlled = player2;
            }
            else
            {
                player2Movement.enabled = false;
                player1Movement.enabled = true;
                currentlyControlled = player1;
            }
        }
    }

    public GameObject GetCurrentlyControlledPlayer()
    {
        return currentlyControlled;
    }
}