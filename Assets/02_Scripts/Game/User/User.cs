public class User : IUser
{
    public DeckData Deck { get; private set; } = new();

    public IMoney Coin { get; private set; }

    public User(IMoney coin)
    {

        Coin = coin;

    }

}
