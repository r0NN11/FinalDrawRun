using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(GameRules))]
[RequireComponent(typeof(SceneManagement))]
public class ScoreManager : MonoBehaviour
{
    private GameRules _gameRules;
    private SceneManagement _sceneManagement;
    public int score { get; private set; }
    private void Start()
    {
        _gameRules = GetComponent<GameRules>();
        _gameRules.OnLevelStart.AddListener(LoadScore);
        _gameRules.OnLevelEnd.AddListener(SaveScore);
        _gameRules.OnGameOver.AddListener(SaveScore);
        _sceneManagement = GetComponent<SceneManagement>();
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
    }
    public void ResetScore()
    {
        score = 0;
    }
    public void ResetPrefScore()
    {
        PlayerPrefs.SetInt("Score", 0);
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }
    public void LoadScore()
    {
        int loadedScore = PlayerPrefs.GetInt("Score");
        score = loadedScore;
    }
}
