using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int addToDesiredScore = 30;


    private void LoadNextLevel()
    {
        UpgradeDesiredScore();
        
        // decrease spawn rate
        
        // add more spawn points
    }

    private void UpgradeDesiredScore()
    {
        GameManager.Instance.DesiredScore += addToDesiredScore;
    }
}
