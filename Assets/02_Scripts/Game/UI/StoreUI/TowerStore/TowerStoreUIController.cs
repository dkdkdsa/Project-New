using SharedData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerStoreUIController;

public class TowerStoreUIController : UIController<ShopInfo, TowerStoreUIView, ActionType>
{


    private Dictionary<TowerStoreSlot, ShopData> _slotBinding = new();
    private IShopManager _shopMgr;

    public enum ActionType
    {
        Click,
        Created
    }

    private void Awake()
    {

        _view.RegisterEvent(ActionType.Click, HandleClick);
        _view.RegisterEvent(ActionType.Created, HandleCreated);
        _shopMgr = Managers.GetManager<IShopManager>(); 

    }

    private void HandleCreated(object[] param)
    {

        var slot = param[0].Cast<TowerStoreSlot>();
        var data = param[1].Cast<ShopData>();

        _slotBinding.Add(slot, data);

    }

    private async void HandleClick(object[] param)
    {

        var slot = param[0].Cast<TowerStoreSlot>();

        if(_slotBinding.TryGetValue(slot, out var data))
        {

            if(await _shopMgr.Buy(data))
            {

                Debug.Log("구매 성공");

            }
            else
            {
                Debug.Log("구매 실패");
            }

        }

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartViewing();
        }

    }

    private async void StartViewing()
    {

        _model = await _shopMgr.GetShopInfo();
        _view.Viewing(_model);
    }

    private void Start()
    {



    }

}
