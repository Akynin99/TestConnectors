using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConnectableService : IService
{
    void ConnectableSpawned(Connectable newConnectable);
    void PickConnectableForDrag(Connectable picked);
    void DragConnectable(Vector3 diff);
}
