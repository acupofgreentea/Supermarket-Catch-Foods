using UnityEngine;

public class ButtonTweener : MonoBehaviour
{
    [SerializeField] private LeanTweenType leanType;

    [SerializeField] private float tweenTime;

    public void OpenLeanScale()
    {
        gameObject.transform.localScale = Vector2.zero;

        LeanTween.scale(gameObject, Vector2.one, tweenTime).setEase(leanType);
    }
}
