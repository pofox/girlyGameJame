using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int currentScore = 0;
    
    // Event that will be triggered when score changes
    public UnityEvent<int> onScoreChanged;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize the UnityEvent if it hasn't been
        if (onScoreChanged == null)
            onScoreChanged = new UnityEvent<int>();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        onScoreChanged.Invoke(currentScore);
    }

    public int GetScore()
    {
        return currentScore;
    }

    // Reset game state
    public void ResetGame()
    {
        currentScore = 0;
        onScoreChanged.Invoke(currentScore);
    }
}