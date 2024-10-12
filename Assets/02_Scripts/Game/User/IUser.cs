using System.Collections.Generic;

public interface IUser
{

    public DeckData Deck { get; }
    public IReadOnlyList<string> Towers { get; }
    public ulong Coin { get; }
    public ulong Jam { get; }

}
