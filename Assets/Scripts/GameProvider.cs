using System.Collections.Generic;
using TestConnectors.Managers;
using TestConnectors.Services;
using UnityEngine;

namespace TestConnectors
{
    // Провайдер берет на себя функцию связывания вместе менеджеров и сервисов, а так же инициализирует их
    public class GameProvider : MonoBehaviour
    {
        [SerializeField] private Main Main;
        [SerializeField] private SpawnManagerSettings SpawnManagerSettings; 
        [SerializeField] private MouseCasterSettings MouseCasterSettings;
        [SerializeField] private LineServiceSettings LineServiceSettings;

        private PlayerControlManager _playerControlManager;
        private SpawnManager _spawnManager;

        private readonly List<IForUpdate> _forUpdates = new List<IForUpdate>();

        private void Awake()
        {
            IMouseCaster mouseCaster = new MouseCaster(MouseCasterSettings);
            IConnectableService connectableService = new ConnectableService();
            ILineService lineService = new LineService(LineServiceSettings);

            _playerControlManager = new PlayerControlManager(mouseCaster, connectableService, lineService);
            _spawnManager = new SpawnManager(connectableService, SpawnManagerSettings, Main.Radius);

            _forUpdates.Add((IForUpdate)_playerControlManager);
        }

        private void Update()
        {
            foreach (var forUpdate in _forUpdates)
            {
                forUpdate.Update();
            }
        }
    }
}