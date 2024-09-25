using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameTag))]
public abstract class UnitBase : MonoBehaviour
{

    protected GameTag _tag;

    protected virtual void Awake()
    {
        _tag = GetComponent<GameTag>();
    }

}