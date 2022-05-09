using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameFinisher : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TextMeshProUGUI _tryAgainText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _returnToLevel1;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private GameRules _gameRules;

    private void Start()
    {
        _gameRules = FindObjectOfType<GameRules>();
        _gameRules.OnLevelEnd.AddListener(NextLevelButtonActivate);
        _gameRules.OnGameOver.AddListener(GameOver);
    }
    private void NextLevelButtonActivate()
    {
        _nextLevelButton.gameObject.SetActive(true);
    }
    private void GameOver()
    {
        _tryAgainText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
        _returnToLevel1.gameObject.SetActive(true);
    }
    public void NextLevel()
    {
        _scoreText.gameObject.SetActive(false);
    }
}
