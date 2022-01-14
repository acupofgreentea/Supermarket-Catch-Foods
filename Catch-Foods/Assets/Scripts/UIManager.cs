using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;


    private void Update() 
    {
        UpdateScoreText();    
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }
}
