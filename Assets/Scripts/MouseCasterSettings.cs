using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0, fileName = "MouseCasterSettings", menuName = "TestConnectors/Mouse Caster Settings")]
public class MouseCasterSettings : ScriptableObject
{
    [SerializeField] private LayerMask SurfaceLayerMask;
    [SerializeField] private LayerMask ClickableLayerMask;
    [SerializeField] private float CastDistance;

    public LayerMask GetSurfaceLayerMask => SurfaceLayerMask;
    public LayerMask GetClickableLayerMask => ClickableLayerMask;
    public float GetCastDistance => CastDistance;
}
