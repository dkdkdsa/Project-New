using UnityEngine;

[RequireComponent(typeof(LocalInstaller))]
public abstract class EnemyBase : UnitBase, ILocalInject
{

    protected IMoveable _move;

    public virtual void LocalInject(ComponentList list)
    {

        _move = list.Find<IMoveable>();

    }

}
