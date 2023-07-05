using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager
{
    private Connectable _connectablePrefab;
    private int _spawnCount;
    private float _radius;
    
    private readonly IConnectableService _connectableService;

    public SpawnManager(IConnectableService connectableService, SpawnManagerSettings settings, float radius)
    {
        _connectableService = connectableService;
        _connectablePrefab = settings.GetPrefab;
        _spawnCount = settings.GetSpawnCount;
        _radius = radius;
        
        Spawn();
    }

    private void Spawn()
    {
        if(_spawnCount <= 0)
            return;

        for (int i = 0; i < _spawnCount; i++)
        {
            _connectableService.ConnectableSpawned(SpawnOnRandomPos(_radius));
        }
    }

    private Connectable SpawnOnRandomPos(float radius)
    {
        Vector2 randomInsideCircle = Random.insideUnitCircle * radius;
        Vector3 randomPos = new Vector3(randomInsideCircle.x, 0, randomInsideCircle.y);

        return SpawnOnPos(randomPos);
    }
    
    private Connectable SpawnOnPos(Vector3 pos)
    {
        Connectable newConnectable = GameObject.Instantiate(_connectablePrefab, pos, Quaternion.identity);
        return newConnectable;
    }
}
