using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectable : MonoBehaviour
{
    [SerializeField] private MeshRenderer PlatformRenderer;
    [SerializeField] private MeshRenderer SphereRenderer;
    [SerializeField] private Transform LinePoint;
    [SerializeField] private Material DefaultMat;
    [SerializeField] private Material BlueMat;
    [SerializeField] private Material YellowMat;

    public Transform GetLinePoint => LinePoint;

    public void SetColor(ConnectableColor color)
    {
        switch (color)
        {
            case ConnectableColor.Blue:
                SphereRenderer.material = BlueMat;
                break;
            
            case ConnectableColor.Yellow:
                SphereRenderer.material = YellowMat;
                break;
            
            default:
                SphereRenderer.material = DefaultMat;
                break;
        }
    }
    
    
}

public enum ConnectableColor
{
    Default = 0,
    Blue = 1,
    Yellow = 2,
}
