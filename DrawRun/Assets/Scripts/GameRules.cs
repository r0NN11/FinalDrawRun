using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(ObjectPlacer))]
public class GameRules : MonoBehaviour
{
    public UnityEvent OnLevelStart { get; private set; } = new UnityEvent();
    public UnityEvent OnLevelEnd { get; private set; } = new UnityEvent();
    public UnityEvent OnGameOver { get; private set; } = new UnityEvent();
    private LevelEnd _levelEnd;
    private ObjectPlacer _objectPlacer;
    private SceneManagement _sceneManagement;
    private bool isLevelStarted;
    public int _level { get; private set; }
    private void Start()
    {
        _levelEnd = FindObjectOfType<LevelEnd>();
        _levelEnd.OnRoundFinal.AddListener(RoundFinal);
        _objectPlacer = GetComponent<ObjectPlacer>();
        _level = PlayerPrefs.GetInt("LevelNum");
        if (!PlayerPrefs.HasKey("LevelNum"))
        {
            _level = 1;
        }
    }
    private void Update()
    {
        if (_objectPlacer.Objects.Count == 0)
        {
            OnGameOver.Invoke();
        }
        StartLevel();
    }
    public void SaveLevelNum()
    {
        PlayerPrefs.SetInt("LevelNum", _level + 1);
    }
    public void DeleteLevelNum()
    {
        PlayerPrefs.DeleteKey("LevelNum");
    }
    private void StartLevel()
    {
        if (Input.GetMouseButtonDown(0) & !isLevelStarted)
        {
            isLevelStarted = true;
            OnLevelStart.Invoke();
        }
    }
    private void RoundFinal()
    {
        OnLevelEnd.Invoke();
        AnalyticsManager.instance.OnLevelComplete(_level);
        FacebookManager.instance.LevelEnded(_level);
        SaveLevelNum();
    }
}
