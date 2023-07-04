using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Main Main;
    [SerializeField] private Connectable ConnectablePrefab;
    [SerializeField, Range(0, 20)] private int SpawnCount;

    private Connectable[] _spawned;

    private void Awake()
    {
        if(!Main)
            return;
        
        if(SpawnCount <= 0)
            return;

        _spawned = new Connectable[SpawnCount];

        for (int i = 0; i < SpawnCount; i++)
        {
            _spawned[i] = SpawnOnRandomPos(Main.Radius);
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
        Connectable newConnectable = Instantiate(ConnectablePrefab, pos, Quaternion.identity);
        return newConnectable;
    }
}
