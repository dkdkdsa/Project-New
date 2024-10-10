public interface IMoney
{

    public int Money { get; }
    public void AddMoney(int amount);
    public void RemoveMoney(int amount);

}
