﻿using TestConnectors.Services;
using TestConnectors.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestConnectors.Managers
{
    // менеджер который отвечает за спавн объектов Connectable в начале игры
    public class SpawnManager
    {
        private readonly ConnectableView _connectablePrefab;
        private readonly int _spawnCount;
        private readonly float _radius;
        private readonly Transform _folder;
        private readonly IConnectableService _connectableService;

        public SpawnManager(IConnectableService connectableService, SpawnManagerSettings settings, float radius)
        {
            _connectableService = connectableService;
            _connectablePrefab = settings.GetPrefab;
            _spawnCount = settings.GetSpawnCount;
            _radius = radius;

            GameObject folderGO = new GameObject();
            folderGO.name = settings.GetFolderName;
            _folder = folderGO.transform;
        
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

        private ConnectableView SpawnOnRandomPos(float radius)
        {
            Vector2 randomInsideCircle = Random.insideUnitCircle * radius;
            Vector3 randomPos = new Vector3(randomInsideCircle.x, 0, randomInsideCircle.y);

            return SpawnOnPos(randomPos);
        }
    
        private ConnectableView SpawnOnPos(Vector3 pos)
        {
            ConnectableView newConnectable = GameObject.Instantiate(_connectablePrefab, pos, Quaternion.identity);
            newConnectable.transform.parent = _folder;
            return newConnectable;
        }
    }
}
