using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _levelBackground;
    private GameRules _gameRules;

    private void Start()
    {
        _gameRules = FindObjectOfType<GameRules>();
        _gameRules.OnLevelStart.AddListener(DeactivateLevelBackground);
    }
    private void Update()
    {
        _levelText.text = "LEVEL " + _gameRules._level;
    }
    private void DeactivateLevelBackground()
    {
        _levelBackground.gameObject.SetActive(false);
    }

}
