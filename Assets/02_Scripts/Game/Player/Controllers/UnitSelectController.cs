using UnityEngine;

public class UnitSelectController : MonoBehaviour, ILocalInject, IController
{

    private IInputController _input;
    private IEventManager _evtMgr;
    private Camera _cam => Camera.main;

    public bool Active { get; set; } = true;

    public void Control(params object[] param)
    {
    }

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputController>();
        _evtMgr = Managers.GetManager<IEventManager>();

        _input.RegisterEvent(Hashs.INPUT_HASH_L_MOUSE_BUTTON, HandleClick);

    }

    private void HandleClick(object[] param)
    {

        if (!Active)
            return;

        var t = param[0].Cast<MouseInputType>();

        if (t == MouseInputType.Down)
        {

            var tower = SelectUnit();

            if(tower != null)
                _evtMgr.NotifyEvent(GlobalEvent.UnitSelect, tower);

        }

    }

    private UnitBase SelectUnit()
    {

        var ray = _cam.ScreenPointToRay(_input.GetValue<Vector2>(Hashs.INPUT_HASH_MOUSE_POSITION));

        var hits = Physics.RaycastAll(ray, 1000);

        foreach (var hit in hits)
        {

            var tag = TagManager.Instance.FindGameTag(hit.GetGameObjectId());

            if (tag.HasTag(Tags.Unit))
            {

                return tag.GetComponent<UnitBase>();

            }

        }

        return null;

    }
}