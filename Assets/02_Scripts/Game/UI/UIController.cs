using UnityEngine;

public abstract class UIController<TModel, TView, TEventKey> : MonoBehaviour, ILocalInject
    where TView : UIView<TModel, TEventKey>
{

    protected TModel _model;
    protected TView _view;

    public virtual void LocalInject(ComponentList list)
    {

        _view = list.Find<TView>();

    }
}
