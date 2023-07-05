using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator<T> : IServiceLocator<T>
{
    private Dictionary<Type, T> _itemsMap = new Dictionary<Type, T>();

    public void Register<TP>(TP newService) where TP : T
    {
        var type = newService.GetType();

        if (_itemsMap.ContainsKey(type))
        {
            Debug.LogError("Type " + type + " already exists!");
        }
        
        _itemsMap.Add(type, newService);
    }

    public void Unregister<TP>(TP service) where TP : T
    {
        var type = service.GetType();
        if (_itemsMap.ContainsKey(type))
        {
            _itemsMap.Remove(type);
        }
    }

    public TP GetService<TP>() where TP : T
    {
        var type = typeof(TP);
        
        if (!_itemsMap.ContainsKey(type))
        {
            Debug.LogError("Service " + type + " missing!");
        }

        return (TP)_itemsMap[type];
    }
}
