using UnityEngine;

namespace TestConnectors.View
{
    // этот класс вешается на те объекты по которым можно кликнуть (платформы и шары)
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