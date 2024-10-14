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
        var info = await AuthenticationService.Instance.GetPlayerInfoAsync();

        Debug.Log(AuthenticationService.Instance.PlayerId);
    }

}
