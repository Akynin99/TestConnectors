using UnityEngine;

namespace TestConnectors.View
{
    // класс который вешается на префаб линии для того чтобы привязывать линии к шарам
    public class LineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer LineRenderer;

        private ConnectableView _start;
        private ConnectableView _end;

        public void SetStart(ConnectableView start)
        {
            _start = start;
            Vector3 startPos = start.GetLinePoint.position;

            Vector3[] poses = { startPos, startPos };
        
            LineRenderer.SetPositions(poses);
        }
    
        public void Connect(ConnectableView end)
        {
            _end = end;
            Vector3 endPos = end.GetLinePoint.position;
        
            LineRenderer.SetPosition(1, endPos);
        }
    
        public void SetEndPos(Vector3 endPos)
        {
            LineRenderer.SetPosition(1, endPos);
        }

        private void Update()
        {
            if (_start)
            {
                Vector3 startPos = _start.GetLinePoint.position;
                LineRenderer.SetPosition(0, startPos);
            }

            if (_end)
            {
                Vector3 endPos = _end.GetLinePoint.position;
                LineRenderer.SetPosition(1, endPos);
            }
        }
    }
}
