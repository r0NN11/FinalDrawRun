using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SawRotator : MonoBehaviour
{
    private float _speed = 2f;
    [SerializeField] private float _zPos;
    [SerializeField] private float _xPos;
    [SerializeField] private bool _isZMoving;
    [SerializeField] private bool _isXMoving;
    private Vector3 zPosition;
    private Vector3 xPosition;
    private Vector3 zxPosition;
    private void Start()
    {
        zPosition = new Vector3(transform.position.x, transform.position.y, _zPos);
        xPosition = new Vector3(_xPos, transform.position.y, transform.position.z);
        zxPosition = new Vector3(_xPos, transform.position.y, _zPos);

        if (_isZMoving)
        {
            StartCoroutine(StartDelay(zPosition));
        }
        if (_isXMoving)
        {
            StartCoroutine(StartDelay(xPosition));
        }
        if (_isZMoving & _isXMoving)
        {
            StartCoroutine(StartDelay(zxPosition));
        }
    }
    private void Update()
    {
        transform.Rotate(0, 0, 60 * Time.deltaTime * _speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController _playerController = other.gameObject.GetComponent<PlayerController>();

        if (_playerController)
        {
            _playerController.Death();
        }
    }
    private void Move(Vector3 position)
    {
        transform.DOMove(position, 2f).SetLoops(2, LoopType.Yoyo);
    }
    IEnumerator StartDelay(Vector3 position)
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Move(position);
        }
    }
}
