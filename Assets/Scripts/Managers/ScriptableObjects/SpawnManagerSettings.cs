using TestConnectors.View;
using UnityEngine;

namespace TestConnectors.Managers
{
    [CreateAssetMenu(order = 0, fileName = "SpawnManagerSettings", menuName = "TestConnectors/Spawn Manager Settings")]
    public class SpawnManagerSettings : ScriptableObject
    {
        [SerializeField] private ConnectableView Prefab;
        [SerializeField, Range(0, 50)] private int SpawnCount;
        [SerializeField] private string SceneFolderName;

        public ConnectableView GetPrefab => Prefab;
        public int GetSpawnCount => SpawnCount;
        public string GetFolderName => SceneFolderName;
    }
}
