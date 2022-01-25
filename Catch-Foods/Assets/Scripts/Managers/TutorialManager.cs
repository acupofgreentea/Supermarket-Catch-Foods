using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;

    [SerializeField] private float delay;
    
    private bool isTutorialFinised;

    private const string tutorialKey = "Tutorial"; 
    private void Start()
    {
        if(PlayerPrefs.GetInt(tutorialKey) == 0)
            StartCoroutine(ControlTutorialPanelCo());
    }
    
    private void ShowTutorialPanel()
    {
        Time.timeScale = 0;
        tutorialPanel.SetActive(true);
    }

    private void HideTutorialPanel()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1;
        
        isTutorialFinised = true;

        PlayerPrefs.SetInt(tutorialKey, isTutorialFinised ? 1 : 0);
    }

    private IEnumerator ControlTutorialPanelCo()
    {
        yield return new WaitForSeconds(delay);

        ShowTutorialPanel();

        yield return new WaitForSecondsRealtime(delay);

        HideTutorialPanel();

        StopAllCoroutines();
    }
}
