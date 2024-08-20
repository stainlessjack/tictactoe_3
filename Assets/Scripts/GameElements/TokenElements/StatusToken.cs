namespace GameElements
{
    public class StatusToken : TokenElement
    {
        // Status Tokens are used to track the status of a player's crew
        // with each of the factions in the city.

        // Initialize the data given an existing status token
        public void Initialize(StatusToken statusToken)
        {
            // Initialize the token element
            base.Initialize(statusToken);
        }

        // Initialize the data given the tokenId
        public void Initialize(string tokenId)
        {
            // Initialize the token element
            base.Initialize(tokenId, TokenType.STATUS);
        }
    }
}