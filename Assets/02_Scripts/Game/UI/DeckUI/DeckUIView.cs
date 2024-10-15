using SharedData;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DeckUIController;

public class DeckUIView : UIView<DeckUIModel, ActionType>
{

    [Header("Deck & Tower")]
    [SerializeField] private Transform _towersRoot;
    [SerializeField] private Transform _deckRoot;
    [SerializeField] private DeckUISlot _prefab;
    [Header("Tower Info")]
    [SerializeField] private GameObject _infoUIRoot;
    [SerializeField] private Image _infoImage;
    [SerializeField] private TMP_Text _infoText;

    private IResourceManager _resMgr;

    private void Awake()
    {
        
        _resMgr = Managers.GetManager<IResourceManager>();

    }

    public void ViewInfo(UnitDataSO so, bool isEq)
    {

        _infoUIRoot.gameObject.SetActive(true);
        _infoImage.sprite = so.View;
        _infoText.text = isEq ? "해제하기" : "장착하기";

    }

    public void InfoBtnClick()
    {

        _infoUIRoot.gameObject.SetActive(false);
        NotifyEvent(ActionType.InfoClick);

    }

    public override void Viewing(in DeckUIModel model)
    {

        _towersRoot.Clear();
        _deckRoot.Clear();

        foreach(var item in model.Info.Elements)
        {

            var so = _resMgr.GetResource<UnitDataSO>(item);
            var ins = Instantiate(_prefab, _deckRoot);
            ins.SetUp(item, so, this);

        }

        foreach(var item in model.Towers)
        {

            var so = _resMgr.GetResource<UnitDataSO>(item);
            var ins = Instantiate(_prefab, _towersRoot);
            ins.SetUp(item, so, this);

        }

    }

}