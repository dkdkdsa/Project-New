using SharedData;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static DeckUIController;


public class DeckUIController : UIController<DeckUIModel, DeckUIView, ActionType>
{
    
    public enum ActionType
    {

        Create,
        Click

    }

    private IUserControlManager _userMgr;

    private void Awake()
    {

        _userMgr = Managers.GetManager<IUserControlManager>();

        _model = new DeckUIModel();
        _model.Info.elements = _userMgr.User.Deck.unitDataAddress.ToList();
        _model.Towers = _userMgr.User.Towers.ToList();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {

            StartViewing();

        }

    }

    public void StartViewing()
    {

        _view.Viewing(_model);

    }

}
