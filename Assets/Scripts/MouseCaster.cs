using UnityEngine;

public class MouseCaster : IMouseCaster
{
    private LayerMask _surfaceLayerMask;
    private LayerMask _clickableLayerMask;
    private float _castDistance;
    
    public MouseCaster(MouseCasterSettings settings)
    {
        _surfaceLayerMask = settings.GetSurfaceLayerMask;
        _clickableLayerMask = settings.GetClickableLayerMask;
        _castDistance = settings.GetCastDistance;
    }
    
    public Clickable RaycastForClickable()
    {
        Camera camera = Camera.main;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, _castDistance, _clickableLayerMask))
        {
            Clickable clickable = hit.collider.gameObject.GetComponent<Clickable>();

            if (clickable)
                return clickable;
        }

        return null;
    }

    public Vector3 RaycastSurfacePos()
    {
        Camera camera = Camera.main;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, _castDistance, _surfaceLayerMask))
        {
            return hit.point;
        }
        
        Debug.Log("Can't find surface!");
        return Vector3.zero;
    }
}
