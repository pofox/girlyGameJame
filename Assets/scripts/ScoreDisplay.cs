using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        // Subscribe to score changes
        GameManager.Instance.onScoreChanged.AddListener(UpdateScoreDisplay);
        
        // Initialize display
        UpdateScoreDisplay(GameManager.Instance.GetScore());
    }

    private void UpdateScoreDisplay(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    private void OnDestroy()
    {
        // Unsubscribe when destroyed
        if (GameManager.Instance != null)
            GameManager.Instance.onScoreChanged.RemoveListener(UpdateScoreDisplay);
    }
} 