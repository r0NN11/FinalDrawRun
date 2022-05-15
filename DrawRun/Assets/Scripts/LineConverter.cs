using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(DrawLine))]
public class LineConverter : MonoBehaviour
{
    private DrawLine _drawLine;
    public List<Vector3> worldPositions { get; private set; }
    public UnityEvent<Path> OnLineConverted { get; private set; } = new UnityEvent<Path>();
    private void Start()
    {
        _drawLine = GetComponent<DrawLine>();
        _drawLine.OnLineDrawn.AddListener(LineConvert);
    }
    public void LineConvert(List<Vector3> fingerPositions)
    {
        List<Vector3> worldPositions = new List<Vector3>();

        for (int i = 0; i < fingerPositions.Count; i++)
        {
            Vector3 temp = fingerPositions[i];
            temp.z = -temp.x * 2.8f;
            temp.x = temp.y * 2.5f;
            temp.y = 0.5f;
            worldPositions.Add(temp);
        }
        var path = new Path(worldPositions);
        OnLineConverted?.Invoke(path);
    }

}
