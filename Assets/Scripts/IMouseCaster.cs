using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseCaster : IService
{
    Clickable RaycastForClickable(Vector3 mousePos);

    Vector3 RaycastSurfacePos(Vector3 mousePos);

}
