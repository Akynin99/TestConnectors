using UnityEngine;

namespace TestConnectors.View
{
    public class ClickableView : MonoBehaviour
    {
        [SerializeField] private ConnectableView ConnectableParent;
        [SerializeField] private ClickableType Type;

        public ConnectableView Parent => ConnectableParent;
        public ClickableType ClickableType => Type;
    }

    public enum ClickableType
    {
        Platform = 0,
        Connector = 1
    }
}