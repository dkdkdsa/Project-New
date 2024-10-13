using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 지정 웹서버에 접근을 제공하는 클래스
/// </summary>
public class WebServerAccessObject
{

    private readonly string BASE_URL = "https://localhost:7256/";

    protected async void Get(string subUrl)
    {

        var req = UnityWebRequest.Get($"{BASE_URL}{subUrl}");
        var s = req.SendWebRequest();

    }

}
