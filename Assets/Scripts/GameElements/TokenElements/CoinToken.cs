namespace GameElements
{
    public class CoinToken : TokenElement
    {
        // A Coin Token is the base representation of wealth in the game.
        // It can be used to pay for cards, or to gain access to certain
        // Action Spots.

        // Initialize the data given an existing coin token
        public void Initialize(CoinToken coinToken)
        {
            // Initialize the token element
            base.Initialize(coinToken);
        }

        // Initialize the data given the tokenId
        public void Initialize(string tokenId)
        {
            // Initialize the token element
            base.Initialize(tokenId, TokenType.COIN);
        }
    }
}