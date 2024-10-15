using SharedData;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using UnityEngine;

public class WebShopManager : IShopManager
{

    private WebReqester _reqester;
    private IUserControlManager _userMgr;

    public void Init()
    {

        _userMgr = Managers.GetManager<IUserControlManager>();
        _reqester = new WebReqester();

    }


    public async Task<bool> Buy(ShopData target)
    {

        _reqester.url = $"{Urls.BASE_URL}/Shop/BuyTower";
        _reqester.header.Add("AccessToken", AuthenticationService.Instance.AccessToken);

        _reqester.content =
            new StringContent(JsonUtility.ToJson(target),
            Encoding.UTF8, "application/json");

        var response = await _reqester.PostAsync();
        _reqester.header.Clear();

        if (!response.isSuccess)
            return false;

        bool b = await _userMgr.UpdateUser();

        return b;

    }

    public async Task<ShopInfo> GetShopInfo()
    {

        _reqester.url = $"{Urls.BASE_URL}/Shop/GetTowerShopInfo";
        _reqester.header.Add("AccessToken", AuthenticationService.Instance.AccessToken);

        var response = await _reqester.GetAsync();
        _reqester.header.Clear();

        if (!response.isSuccess)
            return null;

        return JsonUtility.FromJson<ShopInfo>(response.value);

    }

    public void Dispose()
    {

        _reqester.Dispose();

    }
}
