using System.Collections.Generic;
using UnityEngine;

public class ComponentList
{

    public ComponentList(Component[] components)
    {

        _components = components;

    }

    private Component[] _components;

    public T Find<T>()
    {

        T ins = default;

        foreach (var component in _components)
        {

            if (component is T)
            {

                ins = component.Cast<T>();

                return ins;

            }

        }

        return ins;

    }

    public TMain Find<TMain, TSub>()
    {

        TMain ins = default;

        foreach (var component in _components)
        {

            if (component is TMain && component is TSub)
            {

                ins = component.Cast<TMain>();

                return ins;

            }

        }

        return ins;

    }


    public List<T> FindAll<T>()
    {

        List<T> list = new List<T>();

        foreach (var component in _components)
        {

            if(component is T)
            {

                list.Add(component.Cast<T>());

            }

        }

        return list;

    }

    public List<TMain> FindAll<TMain, TSub>()
    {

        List<TMain> list = new List<TMain>();

        foreach (var component in _components)
        {

            if (component is TMain && component is TSub)
            {

                list.Add(component.Cast<TMain>());

            }

        }

        return list;

    }

}