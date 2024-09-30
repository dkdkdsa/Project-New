using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreateController : MonoBehaviour, IController, ILocalInject
{

    private IInputController _input;

    public bool Active { get; set; } = true;

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputController>();

    }

    private void Awake()
    {
        

    }

    public void Control()
    {

        if (!Active)
            return;

    }


}
