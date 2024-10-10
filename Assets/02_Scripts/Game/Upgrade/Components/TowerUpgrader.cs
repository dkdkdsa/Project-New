public class TowerUpgrader : StatUpgrader<int, float>
{

    private IMoney _money;

    private void Awake()
    {

        _money = Singletons.GetSingleton<IMoney>();

    }

    protected override bool ApplyCost(int cost)
    {

        if (cost > _money.Money)
            return false;

        _money.RemoveMoney(cost);

        return true;

    }

}
