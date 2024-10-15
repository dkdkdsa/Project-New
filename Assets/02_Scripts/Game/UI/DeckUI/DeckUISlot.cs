using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static DeckUIController;

public class DeckUISlot : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;

    private IEventContainer<ActionType> _event;

    public void SetUp(string address, UnitDataSO so, IEventContainer<ActionType> evt)
    {

        _event = evt;
        _event.NotifyEvent(ActionType.Create, address, this);
        _text.text = so.Name;
        _image.sprite = so.View;

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        _event.NotifyEvent(ActionType.Click, this);

    }

}
