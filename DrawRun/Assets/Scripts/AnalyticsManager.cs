using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        GameAnalytics.Initialize();
    }
    public void OnLevelComplete(int _level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level" + _level);
        Debug.Log("Level " + _level + " complete");
    }
}
