using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerStoreUIController;

public class TowerStoreUIController : UIController<StoreDataSO, TowerStoreUIView, ActionType>
{

    [SerializeField] private StoreDataSO _data;

    private Dictionary<TowerStoreSlot, StoreData> _slotBinding = new();

    public enum ActionType
    {
        Click,
        Created
    }

    private void Awake()
    {

        _model = _data;
        _view.RegisterEvent(ActionType.Click, HandleClick);
        _view.RegisterEvent(ActionType.Created, HandleCreated);

    }

    private void HandleCreated(object[] param)
    {

        var slot = param[0].Cast<TowerStoreSlot>();
        var data = param[1].Cast<StoreData>();

        _slotBinding.Add(slot, data);

    }

    private void HandleClick(object[] param)
    {

        var slot = param[0].Cast<TowerStoreSlot>();

        if(_slotBinding.TryGetValue(slot, out var data))
        {

            Debug.Log((data.obj as UnitDataSO).Name + "을 구매하다");

        }

    }

    private void Start()
    {

        _view.Viewing(_model);

    }

}
