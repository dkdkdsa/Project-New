using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static TowerCreateUIController;

public class TowerSlotUI : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _text;

    private IEventContainer<TowerCreateUIEventType> _event;
    private int _index;

    public void OnPointerDown(PointerEventData eventData)
    {

        _event.NotifyEvent(TowerCreateUIEventType.ClickSlot, _index);

    }

    public void SetUp(IEventContainer<TowerCreateUIEventType> @event, int idx)
    {

        _event = @event;
        _index = idx;

    }

    public void View(Sprite sprite, string text)
    {

        _icon.sprite = sprite;
        _text.text = text;

    }

}
