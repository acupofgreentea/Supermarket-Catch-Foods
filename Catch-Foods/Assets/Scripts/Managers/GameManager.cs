using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int desiredScore = 100;
    [SerializeField] private int addToDesiredScore = 30;

    public int Score {get; set;}

    public float Timer {get; set;}

    public bool IsReadyNextLevel{get; private set;}

    public static Action OnNextLevel;
    private void OnEnable() 
    {
        OnNextLevel += ResetTimeForNextLevel;
        OnNextLevel += ResetScoreForNextLevel;
        OnNextLevel += UpdateDesiredScore;
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
            IsReadyNextLevel = true;
            
            OnNextLevel();
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

    private void OnDisable() 
    {
        OnNextLevel -= ResetTimeForNextLevel;
        OnNextLevel -= ResetScoreForNextLevel;
        OnNextLevel -= UpdateDesiredScore;
    }
}
