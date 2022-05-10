using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _drawingCamera;
    private float _offset;
    public float Offset { get => _offset; set => _offset = value; }
    private void Awake()
    {
        _offset = transform.position.x - _drawingCamera.transform.position.x;
    }
    private void FixedUpdate()
    {
        Vector3 newPos = transform.position;
        newPos.x = _drawingCamera.transform.position.x + _offset;
        transform.position = Vector3.Lerp(transform.position, newPos, 0.2f);
    }
}
