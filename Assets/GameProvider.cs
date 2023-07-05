using System;
using System.Collections.Generic;
using UnityEngine;

public class GameProvider : MonoBehaviour
{
    [SerializeField] private Main Main;
    [SerializeField] private Connectable Prefab;
    [SerializeField] private LayerMask SurfaceLayerMask;
    [SerializeField] private LayerMask ClickableLayerMask;
    [SerializeField] private float CastDistance;

    private PlayerControlManager _playerControlManager;
    private SpawnManager _spawnManager;

    private void Awake()
    {
        InitManagers();
        
    }

    private void InitManagers()
    {
        IMouseCaster mouseCaster = new MouseCaster(SurfaceLayerMask, ClickableLayerMask, CastDistance);
        IConnectableService connectableService = new ConnectableService();
        
        _playerControlManager = new PlayerControlManager(mouseCaster, connectableService);
        _spawnManager = new SpawnManager(connectableService, Prefab, 10, Main.Radius);
    }

    private void Update()
    {
        _playerControlManager.Update();
    }
}
