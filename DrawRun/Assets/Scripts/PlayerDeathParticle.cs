using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class PlayerDeathParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _objectDamageParticle;
    [SerializeField] private ParticleSystem _objectFireDeathParticle;
    private PlayerController _playerController;
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _objectDamageParticle = GetComponentInChildren<ParticleSystem>();
        _playerController.OnDeathEvent.AddListener(ActivateDamageParticle);
        _playerController.OnFireDeathEvent.AddListener(ActivateFireDeathParticle);
    }
    private void ActivateDamageParticle()
    {
        _objectDamageParticle.transform.rotation = Random.rotation;
        _objectDamageParticle.Play();
    }
    private void ActivateFireDeathParticle()
    {
        _objectFireDeathParticle.Play();
    }
}
