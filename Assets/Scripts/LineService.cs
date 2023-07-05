
    using System.Collections.Generic;
    using UnityEngine;

    public class LineService : ILineService
    {
        private Line _notConnectedLine;
        
        private readonly Line _prefab;
        private readonly Transform _folder;
        private readonly List<Line> _lines = new List<Line>();

        public LineService(LineServiceSettings settings)
        {
            _prefab = settings.GetPrefab;
            
            GameObject folderGO = new GameObject();
            folderGO.name = settings.GetFolderName;
            _folder = folderGO.transform;
        }
        
        public void CreateLine(Connectable connectable)
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

        public void ConnectLine(Connectable connectable)
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

        private Line SpawnNewLine()
        {
            Line newLine = GameObject.Instantiate(_prefab, _folder, true);
            _lines.Add(_notConnectedLine);

            return newLine;
        }
    }
