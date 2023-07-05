using System;
using UnityEngine;

public class PlayerControlManager : IForUpdate
{
    private readonly IMouseCaster _mouseCaster;
    private readonly IConnectableService _connectableService;
    private readonly ILineService _lineService;
    
    private ControlState _currentState;
    private Vector3 _lastMousePos;
    private Vector3 _lastMouseSurfacePos;
    private bool _mousePressedLastFrame;

    public PlayerControlManager(IMouseCaster mouseCaster, IConnectableService connectableService, ILineService lineService)
    {
        _mouseCaster = mouseCaster;
        _connectableService = connectableService;
        _lineService = lineService;
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

        Clickable clickable = _mouseCaster.RaycastForClickable();

        if(!clickable)
            return;

        if (clickable.ClickableType == ClickableType.Platform)
        {
            _currentState = ControlState.DraggingPlatform;
            _connectableService.SelectForDrag(clickable.Parent);
            _lastMouseSurfacePos = _mouseCaster.RaycastSurfacePos();
        }
        else if (clickable.ClickableType == ClickableType.Connector)
        {
            _currentState = ControlState.DraggingLine;
            _connectableService.SelectForLine(clickable.Parent);
            _lineService.CreateLine(clickable.Parent);
        }
    }
    
    private void DraggingPlatformStateLogic()
    {
        if(!Input.GetMouseButton(0))
        {
            _currentState = ControlState.Default;
            return;
        }
        
        Vector3 mouseSurfacePos = _mouseCaster.RaycastSurfacePos();

        Vector3 diff = mouseSurfacePos - _lastMouseSurfacePos;

        _connectableService.DragConnectable(diff);

        _lastMouseSurfacePos = mouseSurfacePos;
    }
    
    private void SphereSelectedStateLogic()
    {
        if (!Input.GetMouseButton(0))
            return;
        
        Clickable clickable = _mouseCaster.RaycastForClickable();

        if (clickable && clickable.ClickableType == ClickableType.Connector)
        {
            _lineService.ConnectLine(clickable.Parent);
            _currentState = ControlState.Default;
            _connectableService.UnselectConnectableForLine();
        }
        else
        {
            _lineService.DestroyLine();
            _currentState = ControlState.Default;
            _connectableService.UnselectConnectableForLine();
        }
    }

    private void DraggingLineStateLogic()
    {
        Clickable clickable = _mouseCaster.RaycastForClickable();
        _connectableService.UnselectCandidate();
        
        if (Input.GetMouseButton(0))
        {
            _lineService.SetEndPos(_mouseCaster.RaycastSurfacePos());

            if (clickable && clickable.ClickableType == ClickableType.Connector)
            {
                _connectableService.SelectAsCandidateForConnect(clickable.Parent);
            }
            
            return;
        }

        if (clickable && clickable.ClickableType == ClickableType.Connector)
        {
            if (_connectableService.IsSelected(clickable.Parent))
            {
                _currentState = ControlState.SphereSelected;
            }
            else
            {
                _lineService.ConnectLine(clickable.Parent);
                _currentState = ControlState.Default;
                _connectableService.UnselectConnectableForLine();
            }
        }
        else
        {
            _lineService.DestroyLine();
            _currentState = ControlState.Default;
            _connectableService.UnselectConnectableForLine();
        }
    }
    
    private enum ControlState
    {
        Default = 0,
        DraggingPlatform = 1,
        SphereSelected = 2,
        DraggingLine = 3,
    }
}
