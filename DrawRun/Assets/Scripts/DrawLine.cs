using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DrawPanel))]
public class DrawLine : MonoBehaviour
{
    [SerializeField] private GameObject _linePrefab;
    [SerializeField] private Camera _drawingCam;
    private LineRenderer _lineRenderer;
    private GameObject _currentLine;
    private DrawPanel _drawpanel;
    public List<Vector3> fingerPositions;
    public UnityEvent<List<Vector3>> OnLineDrawn { get; private set; } = new UnityEvent<List<Vector3>>();
    private void Start()
    {
        _drawpanel = GetComponent<DrawPanel>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) & _drawpanel.IsPointerOverUIObject())
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0) & _drawpanel.IsPointerOverUIObject())
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
            Vector3 tempfingerPos = _drawingCam.ScreenToWorldPoint((mousePosition));
            Vector3 localTempFingerPos = _drawingCam.transform.InverseTransformPoint(tempfingerPos);
            if (Vector3.Distance(localTempFingerPos, fingerPositions[fingerPositions.Count - 1]) > 0.1f)
            {
                UpdateLine(localTempFingerPos);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(_currentLine);
            if (fingerPositions.Count > 5)
            {
                OnLineDrawn.Invoke(fingerPositions);
                fingerPositions.Clear();
            }
            else if (_drawpanel.IsPointerOverUIObject())
            {
                Debug.Log("Too short path");
            }
        }
    }
    private void CreateLine()
    {
        _currentLine = Instantiate(_linePrefab, Vector3.zero, Quaternion.identity, _drawingCam.transform);
        _currentLine.transform.localPosition = Vector3.zero;
        _currentLine.transform.localRotation = Quaternion.identity;
        _lineRenderer = _currentLine.GetComponent<LineRenderer>();
        fingerPositions.Clear();
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        Vector3 localFingerPos = _drawingCam.transform.InverseTransformPoint(_drawingCam.ScreenToWorldPoint(mousePosition));
        fingerPositions.Add(localFingerPos);
        fingerPositions.Add(localFingerPos);
        _lineRenderer.SetPosition(0, fingerPositions[0]);
        _lineRenderer.SetPosition(1, fingerPositions[1]);
    }
    private void UpdateLine(Vector3 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, newFingerPos);
    }
    private void OnDestroy()
    {
        OnLineDrawn.RemoveAllListeners();
    }
}
