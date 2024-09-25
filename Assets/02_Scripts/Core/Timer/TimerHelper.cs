using System;
using System.Collections.Generic;

public static class TimerHelper
{

    private readonly static Dictionary<Type, ICloneable> _bindContainer = new()
    {

        {
            typeof(float),
            new FloatTimer()
        },

    };

    public static ITimer<T> StartTimer<T>(T startTime)
    {

        var ins = _bindContainer[typeof(T)].Clone<ITimer<T>>();

        ins.SetTime(startTime);
        ins.StartTimer();

        return ins;

    }

}
