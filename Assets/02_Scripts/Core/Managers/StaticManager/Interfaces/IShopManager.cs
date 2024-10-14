using SharedData;
using System.Threading.Tasks;
using static WebShopManager;

public interface IShopManager : IManager
{

    public Task<ShopInfo> GetShopInfo();
    public Task<bool> Buy(ShopData target);

}
