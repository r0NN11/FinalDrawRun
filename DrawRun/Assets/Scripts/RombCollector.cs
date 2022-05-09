using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RombCollector : MonoBehaviour
{

    private bool _isCollided;
    private ScoreManager _scoreManager;
    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController _playerController = other.gameObject.GetComponent<PlayerController>();

        if (_playerController & !_isCollided)
        {
            _isCollided = true;
            _scoreManager.IncreaseScore(1);
            RombMove();
            StartCoroutine(DestroyWithDelay());
        }
    }
    private void RombMove()
    {
        float newYPos = transform.position.y + 4;
        transform.DOMoveY(newYPos, 0.7f);
    }
    IEnumerator DestroyWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            Vector3 newPos = new Vector3(transform.position.x, 80, -50);
            transform.DOMove(newPos, 0.9f);
            yield return new WaitForSeconds(0.7f);
            Destroy(gameObject);
        }
    }
}
