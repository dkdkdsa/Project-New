using SharedData;
using System.Collections.Generic;

public class WebUser : IUser
{

    private UserInfo _info;
    private DeckData _deck;

    public DeckData Deck
    {
        get
        {

            _deck.unitDataAddress = _info.Decks;
            return _deck;

        }
    }

    public IReadOnlyList<string> Towers => _info.Towers;

    public ulong Coin => _info.Coin;

    public ulong Jam => _info.Jam;

    public WebUser(UserInfo info)
    {
        _info = info;
        _deck = new DeckData { unitDataAddress = _info.Decks };
    }

    public void SetInfo(UserInfo info)
    {
        _info = info;
    }

}
