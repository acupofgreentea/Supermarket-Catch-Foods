using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
