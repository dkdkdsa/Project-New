using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillContainer : MonoBehaviour
{

    private Dictionary<SkillExecuteType, Skill> _container;

    public enum SkillExecuteType
    {

        Invoke,
        Update

    }

    public void RegisterSkill(Skill skill)
    {

        _container.Add(SkillExecuteType.Invoke, skill);

    }

    public void ExecuteSkill(SkillExecuteType type)
    {

        _container[type].Execute();

    }

}
