using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer LineRenderer;

    private Connectable _start;
    private Connectable _end;

    public void SetStart(Connectable start)
    {
        _start = start;
        Vector3 startPos = start.GetLinePoint.position;

        Vector3[] poses = { startPos, startPos };
        
        LineRenderer.SetPositions(poses);
    }
    
    public void Connect(Connectable end)
    {
        _end = end;
        Vector3 endPos = end.GetLinePoint.position;
        
        LineRenderer.SetPosition(1, endPos);
    }
    
    public void SetEndPos(Vector3 endPos)
    {
        LineRenderer.SetPosition(1, endPos);
    }

    private void Update()
    {
        if (_start)
        {
            Vector3 startPos = _start.GetLinePoint.position;
            LineRenderer.SetPosition(0, startPos);
        }

        if (_end)
        {
            Vector3 endPos = _end.GetLinePoint.position;
            LineRenderer.SetPosition(1, endPos);
        }
    }
}
