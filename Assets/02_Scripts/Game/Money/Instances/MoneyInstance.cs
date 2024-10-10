public class MoneyInstance : IMoney
{
    public int Money { get; private set; }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public void RemoveMoney(int amount)
    {
        Money -= amount;
    }

}
