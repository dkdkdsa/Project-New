using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static TowerStatusUIController;

public class TowerStatusUIPanel : MonoBehaviour
{

    [Header("Setting")]
    [SerializeField] private Image _iconImage;
    [SerializeField] private Transform _upgradeStatusRoot;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _sellButton;
    [Header("Prefab")]
    [SerializeField] private TowerStatUpgradeText _textPrefab;

    private IEventContainer<ActionType> _event;

    private void Awake()
    {

        _upgradeButton.onClick.AddListener(HandleUpgrade);
        _sellButton.onClick.AddListener(HandleSell);

    }


    public void SetUp(IEventContainer<ActionType> evt, TowerStatueModel model)
    {

        _event = evt;

        _iconImage.sprite = model.icon;
        _upgradeStatusRoot.Clear();

        if (!(model.statUpgradeDatas.Count > model.currentLevel))
            return;

        foreach (var item in model.statUpgradeDatas[model.currentLevel].datas)
        {

            var stat = model.binding.First(x => x.name.GetHash() == item.statKey);

            float oldV = stat.value;

            Instantiate(_textPrefab, _upgradeStatusRoot)
                .SetText(stat.name, oldV, oldV + item.modify);

        }

    }


    private void HandleSell()
    {
    }

    private void HandleUpgrade()
    {

        _event.NotifyEvent(ActionType.Upgrade);

    }

}
