using TestConnectors.Services;
using TestConnectors.View;
using UnityEngine;

namespace TestConnectors.Managers
{
    // Менеджер который отвечает за логику управления 
    public class PlayerControlManager : IForUpdate
    {
        private readonly IMouseCaster _mouseCaster;
        private readonly IConnectableService _connectableService;
        private readonly ILineService _lineService;
    
        private ControlState _currentState; // текущее состояние 
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

            ClickableView clickable = _mouseCaster.RaycastForClickable();

            if(!clickable)
                return;

            if (clickable.ClickableType == ClickableType.Platform)
            {
                // кликнули по платформе
                _currentState = ControlState.DraggingPlatform;
                _connectableService.SelectForDrag(clickable.Parent);
                _lastMouseSurfacePos = _mouseCaster.RaycastSurfacePos();
            }
            else if (clickable.ClickableType == ClickableType.Connector)
            {
                // кликнули по шару
                _currentState = ControlState.DraggingLine;
                _connectableService.SelectForLine(clickable.Parent);
                _lineService.CreateLine(clickable.Parent);
            }
        }
    
        private void DraggingPlatformStateLogic()
        {
            if(!Input.GetMouseButton(0))
            {
                // отпустили мышку - перестали двигать платформу
                _currentState = ControlState.Default;
                return;
            }
        
            //продолжаем тянуть платформу
            
            Vector3 mouseSurfacePos = _mouseCaster.RaycastSurfacePos();

            Vector3 diff = mouseSurfacePos - _lastMouseSurfacePos;

            _connectableService.DragConnectable(diff);

            _lastMouseSurfacePos = mouseSurfacePos;
        }
    
        private void SphereSelectedStateLogic()
        {
            if (!Input.GetMouseButton(0))
                return;
        
            ClickableView clickableView = _mouseCaster.RaycastForClickable();

            if (clickableView && clickableView.ClickableType == ClickableType.Connector)
            {
                // кликнули по второму шару
                _lineService.ConnectLine(clickableView.Parent);
                _currentState = ControlState.Default;
                _connectableService.UnselectConnectableForLine();
            }
            else
            {
                // кликнули не по шару
                _lineService.DestroyLine();
                _currentState = ControlState.Default;
                _connectableService.UnselectConnectableForLine();
            }
        }

        private void DraggingLineStateLogic()
        {
            ClickableView clickable = _mouseCaster.RaycastForClickable();
            _connectableService.UnselectCandidate();
        
            if (Input.GetMouseButton(0))
            {
                // держим мышку нажатой - линия тянется за курсором
                _lineService.SetEndPos(_mouseCaster.RaycastSurfacePos());

                if (clickable && clickable.ClickableType == ClickableType.Connector)
                {
                    // курсор находится над шаром - подсвечиваем его
                    _connectableService.SelectAsCandidateForConnect(clickable.Parent);
                }
            
                return;
            }

            // отпустили мышку
            
            if (clickable && clickable.ClickableType == ClickableType.Connector)
            {
                // курсор над шаром   
                if (_connectableService.IsSelected(clickable.Parent))
                {
                    // если это тот же шар, откуда мы тянули мышку, то мы просто переходим к Способу 1 (из ТЗ)
                    _currentState = ControlState.SphereSelected;
                }
                else
                {
                    // соединяем шары
                    _lineService.ConnectLine(clickable.Parent);
                    _currentState = ControlState.Default;
                    _connectableService.UnselectConnectableForLine();
                }
            }
            else
            {
                // курсор не над шаром - убираем линию и подсветку шаров
                _lineService.DestroyLine();
                _currentState = ControlState.Default;
                _connectableService.UnselectConnectableForLine();
            }
        }
    
        private enum ControlState
        {
            Default = 0,            // ничего не выбрано
            DraggingPlatform = 1,   // выбрали платформу и двигаем её
            SphereSelected = 2,     // выбрали сферу для соединения 
            DraggingLine = 3,       // тянем линию от сферы 
        }
    }
}
