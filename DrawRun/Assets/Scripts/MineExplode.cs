using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MineExplode : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private float explosionStrength = 100;
    private void OnTriggerEnter(Collider other)
    {
        PlayerController _playerController = other.gameObject.GetComponent<PlayerController>();
        Rigidbody _playerRigidbody = _playerController.GetComponent<Rigidbody>();
        _explosionParticle = gameObject.GetComponentInChildren<ParticleSystem>();
        if (_playerController)
        {
            _playerController.DeathSeveral();
            _explosionParticle.Play();
            StartCoroutine(DestroyMineWithDelay());
        }
    }
    IEnumerator DestroyMineWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
        }
    }
}
