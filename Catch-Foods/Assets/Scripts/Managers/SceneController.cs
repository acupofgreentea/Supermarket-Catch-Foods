using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private RectTransform panel;

    [SerializeField] private float tweenTime;

    [SerializeField] private Sprite[] panelSprites;

    private void Start() 
    {
        ChooseScenePanelSprite();

        SetTransitionPanel(true);

        LeanTween.scale(panel, Vector2.one, 0);

        LeanTween.scale(panel, Vector2.zero, tweenTime).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() 
        => {SetTransitionPanel(false);});
    }
    public void LoadSceneByIndex(int index)
    {
        ChooseScenePanelSprite();

        LeanTween.scale(panel, Vector2.one, 0);
        
        LeanTween.scale(panel, Vector2.zero, tweenTime).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            SetTransitionPanel(false);
            SceneManager.LoadSceneAsync(index);
        }
        );
        
    }

    private Sprite ChooseScenePanelSprite()
    {
        return panel.GetComponent<Image>().sprite = panelSprites[Random.Range(0, panelSprites.Length)];
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
