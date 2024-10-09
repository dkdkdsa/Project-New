using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreateController : MonoBehaviour, IController, ILocalInject
{

    [SerializeField] private Tags _targetTag;

    /// <summary>
    /// 움직이는 오브젝트
    /// </summary>
    private GameObject _controlObject;

    private IInputController _input;
    private IFactory<GameObject> _factory;
    private Camera _camera;
    private string _address;

    public bool Active { get; set; } = true;
    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputController>();
        _factory = Factorys.GetFactory<IFactory<GameObject>>();

    }

    private void Awake()
    {

        _input.RegisterEvent(Hashs.INPUT_HASH_L_MOUSE_BUTTON, HandleLeftKey);
        _camera = Camera.main;

    }

    private void HandleLeftKey(object[] param)
    {

        if (!Active || _controlObject == null)
            return;

        var t = param[0].Cast<MouseInputType>();

        if(t == MouseInputType.Down)
        {

            var ins = _factory.CreateInstance(new PrefabData { prefabKey = _address });
            ins.transform.position = _controlObject.transform.position;

            Destroy(_controlObject);
        }

    }

    public void Control(params object[] param)
    {

        if (!Active)
            return;

        FollowObject();

    }

    private void FollowObject()
    {

        if (_controlObject == null)
            return;

        var ray = _camera.ScreenPointToRay(_input.GetValue<Vector2>(Hashs.INPUT_HASH_MOUSE_POSITION));
        var rays = Physics.RaycastAll(ray);

        if (rays.Length > 0)
        {

            Vector3 targetPos = Vector3.zero;
            bool isSet = false;

            foreach(var item in rays)
            {

                var tag = TagManager.Instance.FindGameTag(item.GetGameObjectId());

                if (tag == null)
                    continue;

                if (tag.HasTag(_targetTag))
                {

                    targetPos = item.point;
                    isSet = true;
                    break;

                }

            }

            if (isSet)
            {

                _controlObject.transform.position = targetPos;

            }

        }

    }

    public void StartTowerCreate(GameObject obj, string address)
    {

        _controlObject = obj;
        _address = address;

    }

}
