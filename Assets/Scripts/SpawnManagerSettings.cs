using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0, fileName = "SpawnManagerSettings", menuName = "TestConnectors/Spawn Manager Settings")]
public class SpawnManagerSettings : ScriptableObject
{
    [SerializeField] private Connectable Prefab;
    [SerializeField, Range(0, 50)] private int SpawnCount;
    [SerializeField] private string SceneFolderName;

    public Connectable GetPrefab => Prefab;
    public int GetSpawnCount => SpawnCount;
    public string GetFolderName => SceneFolderName;
}
