using UnityEngine;

public class MouseCaster : IMouseCaster
{
    private LayerMask _surfaceLayerMask;
    private LayerMask _clickableLayerMask;
    private float _castDistance;
    
    public MouseCaster(LayerMask surfaceLayerMask, LayerMask clickableLayerMask, float castDistance)
    {
        _surfaceLayerMask = surfaceLayerMask;
        _clickableLayerMask = clickableLayerMask;
        _castDistance = castDistance;
    }
    
    public Clickable RaycastForClickable(Vector3 mousePos)
    {
        Camera camera = Camera.main;

        Ray ray = camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out var hit, _castDistance, _clickableLayerMask))
        {
            Clickable clickable = hit.collider.gameObject.GetComponent<Clickable>();

            if (clickable)
                return clickable;
        }

        return null;
    }

    public Vector3 RaycastSurfacePos(Vector3 mousePos)
    {
        Camera camera = Camera.main;

        Ray ray = camera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out var hit, _castDistance, _surfaceLayerMask))
        {
            return hit.point;
        }
        
        Debug.Log("Can't find surface!");
        return Vector3.zero;
    }
}
