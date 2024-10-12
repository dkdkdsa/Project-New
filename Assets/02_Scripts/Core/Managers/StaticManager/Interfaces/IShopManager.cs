using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopManager
{

    public void GetShopInfo();
    public void Buy(string target, Action<bool> completeCallback);

}
