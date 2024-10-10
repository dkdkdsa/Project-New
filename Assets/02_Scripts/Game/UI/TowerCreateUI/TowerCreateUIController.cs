using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerCreateUIController;

public class TowerCreateUIController : 
    UIController<DeckData, TowerCreateUIView, TowerCreateUIEventType>
{

    private IEventContainer<TowerCreateUIEventType> _event;
    private IResourceManager _resMgr;
    private IFactory<GameObject> _factory;
    private TowerCreateController _controller;
    public enum TowerCreateUIEventType
    {
        ClickSlot
    }

    public override void LocalInject(ComponentList list)
    {

        base.LocalInject(list);
        _event = list.Find<IEventContainer<TowerCreateUIEventType>>();
        _resMgr = Managers.GetManager<IResourceManager>();
        _factory = Factorys.GetFactory<IFactory<GameObject>>();

    }

    private void Awake()
    {
        
        _event.RegisterEvent(TowerCreateUIEventType.ClickSlot, HandleStartCreateTower);
        _controller = FindObjectOfType<TowerCreateController>();

    }

    private void HandleStartCreateTower(object[] param)
    {

        int idx = param[0].Cast<int>();
        var address = _model.unitDataAddress[idx].Replace("_Data", "");

        var ins = _factory.CreateInstance(new PrefabData { prefabKey = address + "_Preview"});

        _controller.StartTowerCreate(ins, address);

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {

            _model = new DeckData();
            _model.unitDataAddress.Add("Tower_Test_Data");
            _view.Viewing(_model);
        }

    }

}
