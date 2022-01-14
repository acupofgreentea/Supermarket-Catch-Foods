using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI timeText;

    private void Update() 
    {
        UpdateScoreText();    
        
        UpdateTimer();
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }

    private void UpdateTimer()
    {
        timeText.text = "Time: " + Mathf.Round(GameManager.Instance.Timer);
    }
}