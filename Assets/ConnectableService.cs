using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectableService : IConnectableService
{
    private List<Connectable> _all = new List<Connectable>();
    private Connectable _pickedForDrag;

    public void ConnectableSpawned(Connectable newConnectable)
    {
        _all.Add(newConnectable);
    }

    public void PickConnectableForDrag(Connectable picked)
    {
        _pickedForDrag = picked;
    }

    public void DragConnectable(Vector3 diff)
    {
        if (!_pickedForDrag)
        {
            Debug.LogError("No Connectable picked for drag!");
        }

        Vector3 pos = _pickedForDrag.transform.position;
        pos += diff;

        _pickedForDrag.transform.position = pos;
    }
}
