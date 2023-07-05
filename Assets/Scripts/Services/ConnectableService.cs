using System.Collections.Generic;
using TestConnectors.View;
using UnityEngine;

namespace TestConnectors.Services
{
    // сервис который нужен для подсветки шаров и изменения позиции объектов Connectable
    public class ConnectableService : IConnectableService
    {
        private List<ConnectableView> _all = new List<ConnectableView>();
        private ConnectableView _selectedForDrag;
        private ConnectableView _selectedForLine;
        private ConnectableView _candidate;

        public void ConnectableSpawned(ConnectableView newConnectable)
        {
            _all.Add(newConnectable);
        }

        public void SelectForDrag(ConnectableView selected)
        {
            _selectedForDrag = selected;
        }

        public void DragConnectable(Vector3 diff)
        {
            if (!_selectedForDrag)
            {
                Debug.LogError("No Connectable picked for drag!");
            }

            Vector3 pos = _selectedForDrag.transform.position;
            pos += diff;

            _selectedForDrag.transform.position = pos;
        }

        public void SelectForLine(ConnectableView selected)
        {
            _selectedForLine = selected;

            foreach (var connectable in _all)
            {
                ConnectableColor color = connectable == selected ? ConnectableColor.Yellow : ConnectableColor.Blue;
            
                connectable.SetColor(color);
            }
        }

        public void UnselectConnectableForLine()
        {
            _selectedForLine = null;
        
            foreach (var connectable in _all)
            {
                ConnectableColor color =  ConnectableColor.Default;
            
                connectable.SetColor(color);
            }
        }

        public bool IsSelected(ConnectableView connectable)
        {
            if (!connectable)
                return false;
        
            return connectable == _selectedForLine;
        }

        public void SelectAsCandidateForConnect(ConnectableView connectable)
        {
            connectable.SetColor(ConnectableColor.Yellow);
            _candidate = connectable;
        }

        public void UnselectCandidate()
        {
            if(!_candidate)
                return;
        
            if(_candidate != _selectedForLine)
                _candidate.SetColor(ConnectableColor.Blue);
        
            _candidate = null;
        }
    }
}
