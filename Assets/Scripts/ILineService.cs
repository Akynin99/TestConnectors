using UnityEngine;

public interface ILineService : IService
{
    void CreateLine(Connectable connectable);
    void SetEndPos(Vector3 pos);
    void ConnectLine(Connectable connectable);
    void DestroyLine();
}
