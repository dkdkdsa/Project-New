using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerStatusUIController;

public class TowerStatusUIView : UIView<TowerStatueModel, ActionType>
{

    [SerializeField] private TowerStatusUIPanel _panel;

    public override void Viewing(in TowerStatueModel model)
    {

        _panel.gameObject.SetActive(true);
        _panel.SetUp(this, model);

    }

}
