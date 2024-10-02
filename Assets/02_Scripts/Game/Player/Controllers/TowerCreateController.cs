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
    private IFactory<ISpawnable> _factory;
    private Camera _camera;

    public bool Active { get; set; } = true;

    public void LocalInject(ComponentList list)
    {

        _input = list.Find<IInputController>();

    }

    private void Awake()
    {

        _input.RegisterEvent(Hashs.INPUT_HASH_L_MOUSE_BUTTON, HandleLeftKey);
        _camera = Camera.main;
        _factory = Factorys.GetFactory<IFactory<ISpawnable>>();

    }

    private void HandleLeftKey(object[] param)
    {

        if (!Active)
            return;

        var t = param[0].Cast<MouseInputType>();

        if(t == MouseInputType.Down)
        {

            _controlObject = null;
            //타워 생성

        }

    }

    public void Control()
    {

        if (!Active)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {



            //StartTowerCreate();

        }

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

                var tag = TagManager.Instance.FindGameTag(item.GatGameObjectId());

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

    public void StartTowerCreate(GameObject prefab)
    {

        _controlObject = Instantiate(prefab);

    }

}
