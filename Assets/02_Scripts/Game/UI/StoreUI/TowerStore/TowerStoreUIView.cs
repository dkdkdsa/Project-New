using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerStoreUIController;

public class TowerStoreUIView : UIView<StoreDataSO, ActionType>
{

    [SerializeField] private TowerStoreSlot _prefab;
    [SerializeField] private Transform _root;

    public override void Viewing(in StoreDataSO model)
    {

        foreach(var item in model.StoreDatas)
        {

            var ins = Instantiate(_prefab, _root);
            ins.SetUp(this, item);

        }

    }

}
