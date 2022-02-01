using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private RectTransform panel;

    [SerializeField] private float tweenTime = 0.7f;

    private void Start() 
    {
        SetTransitionPanel(true);

        LeanTween.scale(panel, Vector2.one, 0);

        LeanTween.scale(panel, Vector2.zero, tweenTime).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() 
        => {SetTransitionPanel(false);});
    }
    public void LoadSceneByIndex(int index)
    {
        LeanTween.scale(panel, Vector2.one, 0);
        
        LeanTween.scale(panel, Vector2.zero, tweenTime).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => 
        {SetTransitionPanel(false);});

        SceneManager.LoadSceneAsync(index);
    }

    private void SetTransitionPanel(bool active)
    {
        panel.gameObject.SetActive(active);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
