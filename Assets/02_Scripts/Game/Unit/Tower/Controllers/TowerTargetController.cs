using System.Collections.Generic;
using UnityEngine;

public class TowerTargetController : MonoBehaviour, IController, ILocalInject
{

    private IValueContainer<int> _value;

    public bool Active { get; set; }

    public void LocalInject(ComponentList list)
    {

        _value = list.Find<IValueContainer<int>>();

    }

    public void Control(params object[] param)
    {

        float range = _value.GetValue<float>(Hashs.TOWER_VALUE_RANGE);

        var finds = Physics.OverlapSphere(transform.position, range);

        List<Transform> enemys = new List<Transform>();

        foreach (var item in finds)
        {

            var tag = TagManager.Instance.FindGameTag(item.GetGameObjectId());

            if (tag != null && tag.HasTag(Tags.Enemy))
            {

                enemys.Add(tag.transform);

            }

        }

        float minDist = float.MaxValue;
        Transform target = null;

        foreach (var item in enemys)
        {

            var dist = Vector3.Distance(transform.position, item.position);
            if (dist < minDist && dist <= range)
            {

                minDist = dist;
                target = item;

            }

        }

        _value.SetValue(Hashs.TOWER_VALUE_TARGET, target);

    }

}
