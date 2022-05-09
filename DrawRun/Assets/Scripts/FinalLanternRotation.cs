using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalLanternRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10;
    [SerializeField] private float _maxAngle = 100;
    [SerializeField] private float _minAngle = 10;
    private void Update()
    {
        transform.localEulerAngles = new Vector3(Mathf.PingPong(Time.time * _rotationSpeed, _minAngle) - _maxAngle, transform.rotation.y, transform.rotation.z);
    }
}
