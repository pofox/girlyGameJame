using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject panel;
    private bool inout = false;

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

    public void move()
    {
        panel.transform.position = new Vector3(inout ? -22 : 49, panel.transform.position.y, 0);
        inout = !inout;
    }

    private void OnDestroy()
    {
        // Unsubscribe when destroyed
        if (GameManager.Instance != null)
            GameManager.Instance.onScoreChanged.RemoveListener(UpdateScoreDisplay);
    }
} 