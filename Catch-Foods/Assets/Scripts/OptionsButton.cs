using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private float tweenTime;
    private void Start() 
    {
        settingsPanel.transform.localScale = Vector2.zero;
    }
    public void OpenOptions()
    {
        settingsPanel.SetActive(true);
        settingsPanel.LeanScale(Vector2.one, tweenTime);
    }

    public void CloseOptions()
    {
        settingsPanel.LeanScale(Vector2.zero, tweenTime).setEaseInBack().setOnComplete(() => settingsPanel.SetActive(false));
    }
}
