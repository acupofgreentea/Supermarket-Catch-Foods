using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;

    [SerializeField] private bool isTutorialFinised = false;

    [SerializeField] private float delay;
    
    private void Start()
    {
        StartCoroutine(ControlTutorialPanelCO());
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
    }

    private IEnumerator ControlTutorialPanelCO()
    {
        yield return new WaitForSeconds(delay);

        ShowTutorialPanel();

        yield return new WaitForSecondsRealtime(delay);

        HideTutorialPanel();

        StopAllCoroutines();
    }
}
