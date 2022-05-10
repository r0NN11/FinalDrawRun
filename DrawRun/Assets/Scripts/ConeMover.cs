using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ConeMover : MonoBehaviour
{
    [SerializeField] private float _delay = 1.5f;
    private Vector3 upPosition;
    private Vector3 downPosition;
    private void Awake()
    {
        upPosition = transform.localPosition;
    }
    private void Start()
    {
        downPosition = new Vector3(transform.position.x, -2, transform.position.z);
        transform.position = downPosition;
        StartCoroutine(StartDelay());
    }
    private void Move()
    {
        transform.DOLocalMoveY(upPosition.y, 0.6f).SetLoops(2, LoopType.Yoyo);
    }
    IEnumerator StartDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Move();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController _playerController = other.gameObject.GetComponent<PlayerController>();

        if (_playerController)
        {
            _playerController.Death();
        }
    }
}

