using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] private Connectable ConnectableParent;
    [SerializeField] private ClickableType Type;

    public Connectable Parent => ConnectableParent;
    public ClickableType ClickableType => Type;
}

public enum ClickableType
{
    Platform = 0,
    Connector = 1
}