using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserControlManager : IManager
{

    /// <summary>
    /// 유저를 생성함
    /// </summary>
    public void CreateUser(Action<IUser> createdCallback);


    /// <summary>
    /// 유저 정보를 초기화
    /// </summary>
    public void UpdateUser(Action<IUser> updateCallback);

}
