using System;
using System.Collections.Generic;
using UnityEngine;

public class GameProvider : MonoBehaviour
{
    [SerializeField] private Main Main;
    [SerializeField] private SpawnManagerSettings SpawnManagerSettings;
    [SerializeField] private MouseCasterSettings MouseCasterSettings;

    private PlayerControlManager _playerControlManager;
    private SpawnManager _spawnManager;

    private void Awake()
    {
        InitManagers();
        
    }

    private void InitManagers()
    {
        IMouseCaster mouseCaster = new MouseCaster(MouseCasterSettings);
        IConnectableService connectableService = new ConnectableService();
        
        _playerControlManager = new PlayerControlManager(mouseCaster, connectableService);
        _spawnManager = new SpawnManager(connectableService, SpawnManagerSettings, Main.Radius);
    }

    private void Update()
    {
        _playerControlManager.Update();
    }
}
