using System.Collections.Generic;

public interface IUser
{

    public DeckData Deck { get; }
    public List<string> Towers { get; }
    public IMoney Coin { get; }

}
