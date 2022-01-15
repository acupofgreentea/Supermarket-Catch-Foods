using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int desiredScore = 100;
    [SerializeField] private int addToDesiredScore = 30;

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
        if(Score >= desiredScore)
        {
            OnNextLevel();
        }
        else
        {
            OnFailedLevel();
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
        desiredScore += addToDesiredScore;
    }

    private void ResetTimeForNextLevel()
    {
        Timer = 10;
    }

    private void ResetScoreForNextLevel()
    {
        Score = 0;
    }

    private void CheckGameOver()
    {
        IsGameOver = true;
    }

    private void OnDisable() 
    {
        OnNextLevel -= ResetTimeForNextLevel;
        OnNextLevel -= ResetScoreForNextLevel;
        OnNextLevel -= UpdateDesiredScore;

        OnFailedLevel -= CheckGameOver;
    }
}
