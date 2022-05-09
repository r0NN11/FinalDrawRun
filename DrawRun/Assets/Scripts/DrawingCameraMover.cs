using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(GameRules))]
[RequireComponent(typeof(PlayersMover))]
public class DrawingCameraMover : MonoBehaviour
{
    [SerializeField] private GameObject _drawingCamera;
    private PlayersMover _playersMover;
    private GameRules _gameRules;
    private bool _isGameActive;
    private void Start()
    {
        _playersMover = GetComponent<PlayersMover>();
        _gameRules = GetComponent<GameRules>();
        _gameRules.OnLevelStart.AddListener(StartMove);
        _gameRules.OnLevelEnd.AddListener(StopMove);
        _gameRules.OnGameOver.AddListener(StopMove);
    }
    private void FixedUpdate()
    {
        if (_isGameActive)
        {
            _drawingCamera.transform.Translate(Vector3.forward * _playersMover.Speed * Time.deltaTime);
        }
    }
    private void StartMove()
    {
        _isGameActive = true;
    }
    private void StopMove()
    {
        _isGameActive = false;
    }
}
