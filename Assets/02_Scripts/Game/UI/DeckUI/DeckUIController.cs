using SharedData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using static DeckUIController;


public class DeckUIController : UIController<DeckUIModel, DeckUIView, ActionType>
{
    
    public enum ActionType
    {

        Create,
        Click,
        InfoClick
    }

    private Dictionary<DeckUISlot, string> _addressContainer = new();
    private IUserControlManager _userMgr;
    private IResourceManager _resMgr;
    private string _currentAddress;

    private void Awake()
    {

        _userMgr = Managers.GetManager<IUserControlManager>();
        _resMgr = Managers.GetManager<IResourceManager>();



        _view.RegisterEvent(ActionType.Create, HandleCreate);
        _view.RegisterEvent(ActionType.Click, HandleClick);
        _view.RegisterEvent(ActionType.InfoClick, HandleInfoClick);

    }

    private void HandleInfoClick(object[] param)
    {

        if (_currentAddress == null)
            return;

        //해제
        if (_model.Info.Elements.Contains(_currentAddress))
        {

            _model.Info.Elements.Remove(_currentAddress);
            _model.Towers.Add(_currentAddress);

        }
        else if(_model.Info.elements.Count < 5)
        {

            _model.Info.Elements.Add(_currentAddress);
            _model.Towers.Remove(_currentAddress);

        }

        _currentAddress = "";
        _addressContainer.Clear();

        StartViewing();

    }

    private void HandleClick(object[] param)
    {

        var slot = param[0].Cast<DeckUISlot>();
        var address = _addressContainer[slot];
        var so = _resMgr.GetResource<UnitDataSO>(address);
        bool eq = _model.Info.Elements.Contains(address);

        _currentAddress = address;
        _view.ViewInfo(so, eq);

    }

    private void HandleCreate(object[] param)
    {

        var address = param[0].Cast<string>();
        var slot = param[1].Cast<DeckUISlot>();

        _addressContainer.Add(slot, address);

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {

            _model = new DeckUIModel();
            _model.Info.elements = _userMgr.User.Deck.unitDataAddress.ToList();
            List<string> towerList = _userMgr.User.Towers.ToList();
            foreach (var item in _userMgr.User.Deck.unitDataAddress)
            {
                towerList.Remove(item);
            }

            _model.Towers = towerList;

            StartViewing();

        }

        if (Input.GetKeyDown(KeyCode.P))
        {

            SaveDeck();

        }

    }

    public async Task SaveDeck()
    {
        if(await _userMgr.SetDeck(_model.Info))
        {
            Debug.Log("저장 성공");
        }
        else
        {
            Debug.Log("저장 실패");
        }
    }

    public void StartViewing()
    {

        _view.Viewing(_model);

    }

}
