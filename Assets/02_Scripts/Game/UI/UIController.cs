using UnityEngine;

public abstract class UIController<TModel, TView, TEventKey> : MonoBehaviour
    where TView : UIView<TModel, TEventKey>
{

    protected TModel _model;
    protected TView _view;

}
