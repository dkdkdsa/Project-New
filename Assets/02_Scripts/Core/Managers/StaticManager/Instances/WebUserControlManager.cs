using SharedData;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using UnityEngine;

public class WebUserControlManager : IUserControlManager
{

    private WebReqester _reqester;
    private WebUser _user;
    public IUser User => _user;

    public void Init()
    {
        _reqester = new();
        _user = new();
        UpdateUser();

    }

    public async Task<bool> CreateUser()
    {


        _reqester.url = $"{Urls.BASE_URL}/User/Add";
        _reqester.header.Add("AccessToken", AuthenticationService.Instance.AccessToken);

        var response = await _reqester.PostAsync();
        _reqester.header.Clear();

        return response.isSuccess;

    }

    public async Task<bool> UpdateUser()
    {


        _reqester.url = $"{Urls.BASE_URL}/User/GetData";
        _reqester.header.Add("AccessToken", AuthenticationService.Instance.AccessToken);

        var response = await _reqester.GetAsync();
        _reqester.header.Clear();

        if (response.isSuccess)
        {

            var info = JsonUtility.FromJson<UserInfo>(response.value);
            _user.SetInfo(info);

        }

        return response.isSuccess;


    }

    public async Task<bool> SetDeck(DeckInfo info)
    {

        Debug.Log(JsonUtility.ToJson(info));

        _reqester.url = $"{Urls.BASE_URL}/User/SetDeck";
        _reqester.header.Add("AccessToken", AuthenticationService.Instance.AccessToken);
        _reqester.content = new StringContent(
            JsonUtility.ToJson(info),
            Encoding.UTF8,
            "application/json");


        var response = await _reqester.PostAsync();
        Debug.Log(response.statusCode);
        _reqester.header.Clear();
        _reqester.content = null;

        return response.isSuccess;

    }

    public void Dispose()
    {

        _reqester.Dispose();

    }

}
