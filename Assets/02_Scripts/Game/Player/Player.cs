using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LocalInstaller))]
public class Player : MonoBehaviour, ILocalInject
{

    private List<IController> _controllers;

    public void LocalInject(ComponentList list)
    {

        _controllers = list.FindAll<IController>();

    }

    private void Update()
    {

        foreach (var controller in _controllers)
        {

            if (!controller.Active)
                continue;

            controller.Control();

        }

    }

}
