using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;
    private GameRules _gameRules;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _playerController.OnDeathEvent.AddListener(Ragdoll);
        _gameRules = FindObjectOfType<GameRules>();
        _gameRules.OnLevelStart.AddListener(ActivateRunningAnimation);
        _gameRules.OnLevelEnd.AddListener(ActivateVictoryAnimation);
    }
    private void Ragdoll()
    {
        _animator.enabled = false;
    }
    private void ActivateRunningAnimation()
    {
        _animator.SetTrigger("LevelStart");
    }
    private void ActivateVictoryAnimation()
    {
        _animator.SetTrigger("LevelEnd");
    }
}
