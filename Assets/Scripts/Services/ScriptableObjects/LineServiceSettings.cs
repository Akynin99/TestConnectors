using TestConnectors.View;
using UnityEngine;

namespace TestConnectors.Services
{
    [CreateAssetMenu(order = 0, fileName = "LineServiceSettings", menuName = "TestConnectors/Line Service Settings")]
    public class LineServiceSettings : ScriptableObject
    {
        [SerializeField] private string SceneFolderName;
        [SerializeField] private LineView LinePrefab;

        public string GetFolderName => SceneFolderName;
        public LineView GetPrefab => LinePrefab;
    }
}
