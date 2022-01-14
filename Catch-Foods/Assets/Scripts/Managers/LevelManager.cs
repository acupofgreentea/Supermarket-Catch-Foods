using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public static Action OnNextLevel;

    private void Update() 
    {
        if(GameManager.Instance.IsReadyNextLevel)
        {
            OnNextLevel();
            Debug.Log("works");
            
            // add more spawn points
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            
         // fail level => show ui 
    }
}
