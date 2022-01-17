using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{

#if UNITY_ANDROID
    string gameId = "4562893";
#else
    string gameId = "4562892";
#endif
    private void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
    }
    private void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    public void PlayRewardedAd()
    {
        if(Advertisement.IsReady("AddPoint"))
        {
            Advertisement.Show("AddPoint");
        }
        else
        {
            Debug.Log("error");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == "AddPoint" && showResult == ShowResult.Finished)
        {
            GameManager.Instance.AddPointAfterRewardedVideo();
        }
    }
}