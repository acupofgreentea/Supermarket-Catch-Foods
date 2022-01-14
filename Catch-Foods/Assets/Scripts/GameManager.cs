using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int Score{get; set;}

    public float Timer {get; set;}

    [SerializeField] private int desiredScore = 100;
    public int DesiredScore {get => desiredScore; set => desiredScore = value;}
    
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start() 
    {
        Timer = 10f;
    }

    private void Update() 
    {
        if(Timer >= 0f)
        {
            UpdateTime();
        }
        else
        {
            PauseGame();

            CheckScore();
        }
    }

    private void CheckScore()
    {
        if(desiredScore >= Score)
            {
                // fail level => show ui 
                // restart game => reload scene
            }
            else
            {
                // load next level => levelmanager.instance.LoadNextLevel
            }
    }

    private void UpdateTime()
    {
        Timer -= Time.deltaTime;
    }

    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }
}
