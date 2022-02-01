using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    private void Start() 
    {
        settingsPanel.transform.localScale = Vector2.zero;
    }
    public void OpenOptions()
    {
        settingsPanel.SetActive(true);
        settingsPanel.LeanScale(Vector2.one, 0.5f);
    }

    public void CloseOptions()
    {
        settingsPanel.LeanScale(Vector2.zero, 0.5f).setEaseInBack().setOnComplete(() => settingsPanel.SetActive(false));
    }
}
