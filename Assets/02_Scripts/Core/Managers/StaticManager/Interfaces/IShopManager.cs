using SharedData;
using System.Threading.Tasks;

public interface IShopManager
{

    public Task<ShopInfo> GetShopInfo();
    public Task<bool> Buy(string target);

}
