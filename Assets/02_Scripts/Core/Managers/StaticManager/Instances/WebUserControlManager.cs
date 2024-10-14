using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WebUserControlManager : IUserControlManager
{


    public void Init()
    {


    }

    public Task<IUser> CreateUser(Action<IUser> createdCallback)
    {
        
    }


    public Task<bool> UpdateUser()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }


}
