using UnityEngine;

public abstract class TowerControllerBase : MonoBehaviour, IController, ILocalInject
{

    protected TowerBase _owner;

    public bool Active { get; set; }

    public abstract void Control();

    public void LocalInject(ComponentList list)
    {

        _owner = list.Find<TowerBase>();

    }

}
