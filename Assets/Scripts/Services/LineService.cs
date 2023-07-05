using System.Collections.Generic;
using TestConnectors.View;
using UnityEngine;

namespace TestConnectors.Services
{
    // сервис который отвечает за создание линий, передачу линиям позиций и соединение линий с объектами Connectable
    public class LineService : ILineService
    {
        private LineView _notConnectedLine;
        
        private readonly LineView _prefab;
        private readonly Transform _folder;
        private readonly List<LineView> _lines = new List<LineView>();

        public LineService(LineServiceSettings settings)
        {
            _prefab = settings.GetPrefab;
            
            GameObject folderGO = new GameObject();
            folderGO.name = settings.GetFolderName;
            _folder = folderGO.transform;
        }
        
        public void CreateLine(ConnectableView connectable)
        {
            if (!_notConnectedLine)
                _notConnectedLine = SpawnNewLine();

            _notConnectedLine.gameObject.SetActive(true);
            
            _notConnectedLine.SetStart(connectable);
        }

        public void SetEndPos(Vector3 pos)
        {
            _notConnectedLine.SetEndPos(pos);
        }

        public void ConnectLine(ConnectableView connectable)
        {
            _notConnectedLine.Connect(connectable);
            _notConnectedLine = null;
        }

        public void DestroyLine()
        {
            if(!_notConnectedLine)
                return;
            
            _notConnectedLine.gameObject.SetActive(false);
        }

        private LineView SpawnNewLine()
        {
            LineView newLine = GameObject.Instantiate(_prefab, _folder, true);
            _lines.Add(_notConnectedLine);

            return newLine;
        }
    }
}
