using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private ScoreManager _scoreManager;
    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }
    void Update()
    {
        _scoreText.text = "" + _scoreManager.score;
    }
}
