using TestConnectors.View;
using UnityEngine;

namespace TestConnectors.Services
{
    public interface ILineService : IService
    {
        void CreateLine(ConnectableView connectable);
        void SetEndPos(Vector3 pos);
        void ConnectLine(ConnectableView connectable);
        void DestroyLine();
    }
}
