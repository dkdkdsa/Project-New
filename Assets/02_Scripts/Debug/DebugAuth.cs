using Newtonsoft.Json;
using SharedData;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class DebugAuth : MonoBehaviour
{

    private async void Start()
    {


        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        var userMgr = Managers.GetManager<IUserControlManager>();
        await userMgr.CreateUser();
        await userMgr.UpdateUser();

        Debug.Log(userMgr.User.Deck.unitDataAddress.Count);

    }

}
