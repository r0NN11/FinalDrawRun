using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
[RequireComponent(typeof(ObjectPlacer))]
public class PlayersMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _finalZpositionCoef = 4;
    [SerializeField] private float _finalXpositionCoef = 135;
    public float Speed { get => _speed; }
    private ObjectPlacer _objectPlacer;
    private GameRules _gameRules;
    private bool _isGameActive;
    private void Start()
    {
        _objectPlacer = GetComponent<ObjectPlacer>();
        _gameRules = FindObjectOfType<GameRules>();
        _gameRules.OnLevelStart.AddListener(StartMove);
        _gameRules.OnLevelEnd.AddListener(StopMove);
        _gameRules.OnLevelEnd.AddListener(FinalMove);
        _gameRules.OnGameOver.AddListener(StopMove);
    }
    private void FixedUpdate()
    {
        if (_isGameActive)
        {
            Move(_objectPlacer.Objects, _speed);
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
    private void Move(List<GameObject> players, float speed)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    private void FinalMove()
    {
        float x, y, z;
        float spacing = 1.2f;
        int columns = 8;
        for (int i = 0; i < _objectPlacer.Objects.Count; i++)
        {
            int row = i / columns;
            int column = i % columns;
            x = _finalXpositionCoef + row * spacing;
            y = _objectPlacer.Objects[i].transform.position.y;
            z = _finalZpositionCoef - column * spacing;
            Vector3 pos = new Vector3(x, y, z);
            _objectPlacer.Objects[i].transform.DOMove(pos, 1.3f);
        }
    }

}
