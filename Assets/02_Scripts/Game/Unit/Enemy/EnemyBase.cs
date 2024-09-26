using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LocalInstaller))]
public abstract class EnemyBase : UnitBase, ILocalInject
{

    protected IController _moveController;

    public void LocalInject(ComponentList list)
    {

        _moveController = list.Find<IController>();

    }
}