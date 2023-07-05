using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IServiceLocator <T>
{
    void Register<TP>(TP newService) where TP : T;
    void Unregister<TP>(TP service) where TP : T;
    TP GetService<TP>() where TP : T;
}
