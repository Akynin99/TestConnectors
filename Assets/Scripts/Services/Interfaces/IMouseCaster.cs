using TestConnectors.View;
using UnityEngine;

namespace TestConnectors.Services
{
    public interface IMouseCaster : IService
    {
        ClickableView RaycastForClickable();

        Vector3 RaycastSurfacePos();

    }
}
