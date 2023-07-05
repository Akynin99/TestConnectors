using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectableService : IConnectableService
{
    private List<Connectable> _all = new List<Connectable>();
    private Connectable _selectedForDrag;
    private Connectable _selectedForLine;
    private Connectable _candidate;

    public void ConnectableSpawned(Connectable newConnectable)
    {
        _all.Add(newConnectable);
    }

    public void SelectForDrag(Connectable selected)
    {
        _selectedForDrag = selected;
    }

    public void DragConnectable(Vector3 diff)
    {
        if (!_selectedForDrag)
        {
            Debug.LogError("No Connectable picked for drag!");
        }

        Vector3 pos = _selectedForDrag.transform.position;
        pos += diff;

        _selectedForDrag.transform.position = pos;
    }

    public void SelectForLine(Connectable selected)
    {
        _selectedForLine = selected;

        foreach (var connectable in _all)
        {
            ConnectableColor color = connectable == selected ? ConnectableColor.Yellow : ConnectableColor.Blue;
            
            connectable.SetColor(color);
        }
    }

    public void UnselectConnectableForLine()
    {
        _selectedForLine = null;
        
        foreach (var connectable in _all)
        {
            ConnectableColor color =  ConnectableColor.Default;
            
            connectable.SetColor(color);
        }
    }

    public bool IsSelected(Connectable connectable)
    {
        if (!connectable)
            return false;
        
        return connectable == _selectedForLine;
    }

    public void SelectAsCandidateForConnect(Connectable connectable)
    {
        connectable.SetColor(ConnectableColor.Yellow);
        _candidate = connectable;
    }

    public void UnselectCandidate()
    {
        if(!_candidate)
            return;
        
        if(_candidate != _selectedForLine)
            _candidate.SetColor(ConnectableColor.Blue);
        
        _candidate = null;
    }
}
