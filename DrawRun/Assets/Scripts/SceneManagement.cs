using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SceneManagement : MonoBehaviour
{
    [SerializeField] private string[] _sceneOrder;
    public int CurrentLevelIndex
    {
        get => PlayerPrefs.GetInt("CurrentLevel", 0);
        private set => PlayerPrefs.SetInt("CurrentLevel", value);
    }
    public void RestartGame()
    {
        LoadSceneByLevelIndex(CurrentLevelIndex);
    }
    public void ReturnToLevel1()
    {
        CurrentLevelIndex = 0;
        LoadSceneByLevelIndex(CurrentLevelIndex);
    }
    private void LoadNextLevel()
    {
        CurrentLevelIndex++;
        LoadSceneByLevelIndex(CurrentLevelIndex);
    }
    private void LoadSceneByLevelIndex(int i)
    {
        var sceneName = _sceneOrder[i % _sceneOrder.Length];
        SceneManager.LoadScene(sceneName);
    }
}
