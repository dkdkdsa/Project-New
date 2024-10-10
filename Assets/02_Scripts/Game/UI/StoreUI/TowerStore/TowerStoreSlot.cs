using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static TowerStoreUIController;

public class TowerStoreSlot : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Image _icon;

    private IEventContainer<ActionType> _event;

    public void OnPointerDown(PointerEventData eventData)
    {

        _event.NotifyEvent(ActionType.Click, this);

    }

    public void SetUp(IEventContainer<ActionType> evt, StoreData data)
    {

        var so = data.obj as UnitDataSO;

        _icon.sprite = so.View;
        _nameText.text = data.price.ToString();

        _event = evt;

        _event.NotifyEvent(ActionType.Created, this, data);

    }

}
