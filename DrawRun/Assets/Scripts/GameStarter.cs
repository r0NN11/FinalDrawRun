using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(GameRules))]
public class GameStarter : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI _startLevelText;
    [SerializeField] private Image _startLevel;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private GameRules _gameRules;
    private void Awake()
    {
        _scoreText.gameObject.SetActive(false);
    }
    private void Start()
    {
        _startLevel.gameObject.SetActive(true);
        _gameRules = FindObjectOfType<GameRules>();
        _gameRules.OnLevelStart.AddListener(StartLevel);
    }
    private void StartLevel()
    {
        _startLevel.gameObject.SetActive(false);
        _scoreText.gameObject.SetActive(true);
    }
}
