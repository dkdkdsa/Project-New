using System.Collections.Generic;

public class LocalUser : IUser
{
    public DeckData Deck { get; private set; } = new();
    public IReadOnlyList<string> Towers { get; private set; }
    public ulong Coin { get; private set; }

    public ulong Jam {get; private set;}

}
