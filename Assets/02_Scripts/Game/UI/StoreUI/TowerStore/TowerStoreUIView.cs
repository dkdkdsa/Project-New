using SharedData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerStoreUIController;

public class TowerStoreUIView : UIView<ShopInfo, ActionType>
{

    [SerializeField] private TowerStoreSlot _prefab;
    [SerializeField] private Transform _root;

    private IResourceManager _resMgr;

    private void Awake()
    {
        
        _resMgr = Managers.GetManager<IResourceManager>();

    }

    public override void Viewing(in ShopInfo model)
    {

        foreach(var item in model.Elements)
        {

            var ins = Instantiate(_prefab, _root);
            ins.SetUp(this, _resMgr.GetResource<UnitDataSO>(item.Name), item);

        }

    }

}
