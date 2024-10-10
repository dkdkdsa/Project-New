using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameTag))]
public abstract class UnitBase : MonoBehaviour
{

    [field: SerializeField] public UnitDataSO Data { get; private set; }
    protected GameTag _tag;


    protected virtual void Awake()
    {
        _tag = GetComponent<GameTag>();
    }

}