using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager
{
    private readonly IConnectableService _connectableService;
    private Connectable _connectablePrefab;
    private int _spawnCount;
    private float _radius;

    public SpawnManager(IConnectableService connectableService, Connectable connectablePrefab, int spawnCount, float radius)
    {
        _connectableService = connectableService;
        _connectablePrefab = connectablePrefab;
        _spawnCount = spawnCount;
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
