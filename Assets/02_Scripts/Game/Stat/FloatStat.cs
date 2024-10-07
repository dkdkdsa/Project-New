using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class FloatStat : StatBase<float>
{

    private List<float> _modify = new();

    public override float Value
    {

        get
        {

            float v = _value;

            foreach (var item in _modify)
            {

                v += item;

            }

            return v;

        }

    }

    public FloatStat(FloatStat ins)
    {

        _value = ins._value;
        _modify = ins._modify == null ? new() : ins._modify.ToList();

    }

    public override void AddModify(float value)
    {

        _modify.Add(value);

    }

    public override void RemoveModify(float value)
    {

        _modify.Remove(value);

    }

    public override void SetValue(float value)
    {

        _value = value;

    }

    public override object Clone()
    {

        return new FloatStat(this);

    }

}
