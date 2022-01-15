using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI timeText;

    [SerializeField] private GameObject gameOverPanel;

    private void OnEnable() 
    {
        GameManager.OnFailedLevel += ShowGameOverPanel;
    }

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

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    private void OnDisable() 
    {
        GameManager.OnFailedLevel -= ShowGameOverPanel;
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
