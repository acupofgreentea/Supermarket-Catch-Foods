using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int desiredScore;
    [SerializeField] private int addToDesiredScore;

    public int Score {get; set;}

    public float Timer {get; set;}

    public static Action OnNextLevel;

    public static Action OnFailedLevel;

    public bool IsGameOver{get; set;}
    private void OnEnable() 
    {
        OnNextLevel += ResetTimeForNextLevel;
        OnNextLevel += ResetScoreForNextLevel;
        OnNextLevel += UpdateDesiredScore;

        OnFailedLevel += CheckGameOver;
    }
    
    protected override void Awake()
    {
        base.Awake();

        Timer = 10f;

        IsGameOver = false;
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
        }
    }

    private void CheckScoreForNextLevel()
    {
        if(Score >= desiredScore && !IsGameOver)
        {
            OnNextLevel();
        }
        else
        {
            OnFailedLevel();
        }
    }

    public void AddPointAfterRewardedVideo() => Score += 20;
    
    private void UpdateTime() => Timer -= Time.deltaTime;
    
    private void UpdateDesiredScore() => desiredScore += addToDesiredScore;

    private void ResetTimeForNextLevel() => Timer = 10;

    private void ResetScoreForNextLevel() => Score = 0;

    private void CheckGameOver() => IsGameOver = true;
    
    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;

        if(Score <= 0)
        {
            ResetScoreForNextLevel();
        }
    }

    private void OnDisable() 
    {
        OnNextLevel -= ResetTimeForNextLevel;
        OnNextLevel -= ResetScoreForNextLevel;
        OnNextLevel -= UpdateDesiredScore;

        OnFailedLevel -= CheckGameOver;
    }
}
