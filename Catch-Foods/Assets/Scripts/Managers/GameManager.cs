using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int desiredScore = 100;
    [SerializeField] private float _timer = 60f;
    [SerializeField] private int addToDesiredScore = 30;

    public int Score{get; set;}

    public float Timer {get => _timer; set => _timer = value;}

    public int DesiredScore {get => desiredScore; set => desiredScore = value;}

    public bool IsReadyNextLevel{get; private set;}
    
    private void OnEnable() 
    {
        LevelManager.OnNextLevel += ResetScoreForNextLevel;
        LevelManager.OnNextLevel += UpdateDesiredScore;
        LevelManager.OnNextLevel += CheckScoreForNextLevel;
        LevelManager.OnNextLevel += ResetTimeForNextLevel;
    }
    
    protected override void Awake()
    {
        base.Awake();
    }
    private void Update() 
    {
        if(Timer >= 0f)
        {
            UpdateTime();
        }
        else
        {
            CheckScoreForNextLevel();
            Debug.Log("Checks");
        }
    }

    private void CheckScoreForNextLevel()
    {
        if(desiredScore <= Score)
        {
            IsReadyNextLevel = true;
        }
        else
        {
            IsReadyNextLevel =  false;
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
    
    private void UpdateDesiredScore()
    {
        DesiredScore += addToDesiredScore;
    }

    private void ResetTimeForNextLevel()
    {
        Timer = 10;
    }

    private void ResetScoreForNextLevel()
    {
        Score = 0;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
    
    private void OnDisable()
    {
        LevelManager.OnNextLevel -= ResetScoreForNextLevel;
        LevelManager.OnNextLevel -= UpdateDesiredScore;
        LevelManager.OnNextLevel -= CheckScoreForNextLevel;
        LevelManager.OnNextLevel -= ResetTimeForNextLevel;
    }
}
