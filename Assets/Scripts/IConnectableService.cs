using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConnectableService : IService
{
    void ConnectableSpawned(Connectable newConnectable);
    void SelectForDrag(Connectable selected);
    void DragConnectable(Vector3 diff);
    void SelectForLine(Connectable selected);
    void UnselectConnectableForLine();
    bool IsSelected(Connectable connectable);
    void SelectAsCandidateForConnect(Connectable connectable);
    void UnselectCandidate();
}
