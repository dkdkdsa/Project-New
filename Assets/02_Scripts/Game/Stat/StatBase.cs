using System;
using UnityEngine;

[SerializeField]
public abstract class StatBase<T> : ICloneable
{

    [field:SerializeField] protected T _value;

    public abstract T Value { get; }
    public abstract void AddModify(T value);
    public abstract void RemoveModify(T value);
    public abstract void SetValue(T value);
    public abstract object Clone();

}