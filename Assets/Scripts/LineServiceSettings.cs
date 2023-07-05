using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0, fileName = "LineServiceSettings", menuName = "TestConnectors/Line Service Settings")]
public class LineServiceSettings : ScriptableObject
{
    [SerializeField] private string SceneFolderName;
    [SerializeField] private Line LinePrefab;

    public string GetFolderName => SceneFolderName;
    public Line GetPrefab => LinePrefab;
}
