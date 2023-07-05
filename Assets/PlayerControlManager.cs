using System;
using UnityEngine;

public class PlayerControlManager 
{
    private readonly IMouseCaster _mouseCaster;
    private readonly IConnectableService _connectableService;
    
    private ControlState _currentState;
    // private Clickable _lastClickable;
    private Vector3 _lastMousePos;
    private Vector3 _lastMouseSurfacePos;
    private bool _mousePressedLastFrame;

    public PlayerControlManager(IMouseCaster mouseCaster, IConnectableService connectableService)
    {
        _mouseCaster = mouseCaster;
        _connectableService = connectableService;
    }

    public void Update()
    {
        switch (_currentState)
        {
            case ControlState.DraggingPlatform:
                DraggingPlatformStateLogic();
                break;
            
            case ControlState.SphereSelected:
                SphereSelectedStateLogic();
                break;
            
            case ControlState.DraggingLine:
                DraggingLineStateLogic();
                break;
            
            default:
                DefaultStateLogic();
                break;
        }

        _lastMousePos = Input.mousePosition;
        _mousePressedLastFrame = Input.GetMouseButton(0);
    }

    private void DefaultStateLogic()
    {
        if(!Input.GetMouseButton(0) || _mousePressedLastFrame)
            return;

        Clickable clickable = _mouseCaster.RaycastForClickable(Input.mousePosition);

        if(!clickable)
            return;

        if (clickable.Type == ClickableType.Platform)
        {
            _currentState = ControlState.DraggingPlatform;
            _connectableService.PickConnectableForDrag(clickable.Parent);
            _lastMouseSurfacePos = _mouseCaster.RaycastSurfacePos(Input.mousePosition);
        }
        else if (clickable.Type == ClickableType.Connector)
        {
            // _currentState = ControlState.DraggingLine;
        }
    }
    
    private void DraggingPlatformStateLogic()
    {
        if(!Input.GetMouseButton(0))
        {
            // _lastClickable = null;
            _currentState = ControlState.Default;
            return;
        }
        
        Vector3 mouseSurfacePos = _mouseCaster.RaycastSurfacePos(Input.mousePosition);

        Vector3 diff = mouseSurfacePos - _lastMouseSurfacePos;

        _connectableService.DragConnectable(diff);

        _lastMouseSurfacePos = mouseSurfacePos;
    }
    
    private void SphereSelectedStateLogic()
    {
        
    }
    
    private void DraggingLineStateLogic()
    {
        
    }
    
    private enum ControlState
    {
        Default = 0,
        DraggingPlatform = 1,
        SphereSelected = 2,
        DraggingLine = 3,
    }
}
