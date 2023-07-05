using TestConnectors.View;
using UnityEngine;

namespace TestConnectors.Services
{
    public interface IConnectableService : IService
    {
        void ConnectableSpawned(ConnectableView newConnectable);
        void SelectForDrag(ConnectableView selected);
        void DragConnectable(Vector3 diff);
        void SelectForLine(ConnectableView selected);
        void UnselectConnectableForLine();
        bool IsSelected(ConnectableView connectable);
        void SelectAsCandidateForConnect(ConnectableView connectable);
        void UnselectCandidate();
    }
}
