using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
[RequireComponent(typeof(LineConverter))]
[RequireComponent(typeof(PlayersMover))]
public class ObjectPlacer : MonoBehaviour
{
    private CameraFollow _cameraFollow;
    private List<GameObject> _objects = new List<GameObject>();
    private LineConverter _lineConverter;
    private PlayersMover _playersMover;
    public List<GameObject> Objects { get => _objects; }
    private void Start()
    {
        _lineConverter = GetComponent<LineConverter>();
        _lineConverter.OnLineConverted.AddListener(PlaceObject);
        _cameraFollow = FindObjectOfType<CameraFollow>();
        _playersMover = GetComponent<PlayersMover>();
    }
    private void PlaceObject(Path path)
    {
        float length = path.length;
        float step = length / (_objects.Count);
        float duration = 0.5f;
        Vector3 newCameraPos = Camera.main.transform.position + Vector3.right * duration * _playersMover.Speed;
        for (int i = 0; i < _objects.Count; i++)
        {
            float localLength = i * step;
            Vector3 newPos = _objects[i].transform.position;
            newPos.x = path.GetPointAlongPath(localLength).x + (newCameraPos.x - _cameraFollow.Offset);
            newPos.y = path.GetPointAlongPath(localLength).y;
            newPos.z = path.GetPointAlongPath(localLength).z;
            _objects[i].transform.DOMove(newPos, 0.9f);
        }
    }
    public void AddPlayerObject(GameObject player)
    {
        _objects.Add(player);
    }
    public void RemovePlayerObjects(GameObject player)
    {
        _objects.Remove(player);
    }
    public void RemoveAndDestroySeveralObjects(GameObject _object)
    {
        Destroy(_object);
        _objects.Remove(_object);
        for (int i = _objects.Count - 1; i >= 0; i--)
        {
            float distance = Vector3.Distance(_object.transform.position, _objects[i].transform.position);
            if (distance < 0.5f)
            {
                Destroy(_objects[i]);
                _objects.RemoveAt(i);
            }
        }
    }

}
