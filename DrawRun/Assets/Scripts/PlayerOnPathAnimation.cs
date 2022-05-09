using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerOnPathController))]
public class PlayerOnPathAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerOnPathController _playerOnPathController;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerOnPathController = GetComponent<PlayerOnPathController>();
        _playerOnPathController.OnCollision.AddListener(AnimatorChange);
    }
    private void AnimatorChange(Animator animator)
    {
        _animator.runtimeAnimatorController = animator.runtimeAnimatorController;
        _animator.SetTrigger("LevelStart");
    }

}
