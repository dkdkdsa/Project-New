using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameTag))]
public abstract class UnitBase : MonoBehaviour
{

    [SerializeField] protected UnitDataSO _data;
    protected GameTag _tag;


    protected virtual void Awake()
    {
        _tag = GetComponent<GameTag>();
    }

}