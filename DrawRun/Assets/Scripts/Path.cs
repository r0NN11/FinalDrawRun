using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    public List<Vector3> points { get; }
    public float length { get; }
    public Path(List<Vector3> pathPoints)
    {
        points = pathPoints;
        length = GetWholePathLength();
    }
    private float GetWholePathLength()
    {
        float length = 0f;
        for (int i = 0; i < points.Count - 1; i++)
        {
            length += (points[i + 1] - points[i]).magnitude;
        }
        return length;
    }
    public Vector3 GetPointAlongPath(float distanceAlongPath)
    {
        if (distanceAlongPath > length) return points[points.Count - 1];
        if (distanceAlongPath <= 0) return points[0];

        for (int i = 1; i < points.Count; i++)
        {
            var segment = points[i] - points[i - 1];
            var segmentLen = segment.magnitude;
            if (distanceAlongPath < segmentLen)
            {
                return Vector3.Lerp(points[i - 1], points[i], distanceAlongPath / segmentLen);
            }
            else
            {
                distanceAlongPath -= segmentLen;
            }
        }
        throw new System.Exception("This should not happen");
    }












}
