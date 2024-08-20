namespace GameElements
{
    public class HeatToken : TokenElement
    {
        // A Heat Token is the representation of attention the player has
        // gained from the populace of the city. It is primarily used to
        // punish the player for taking bombastic actions.

        // Initialize the data given an existing heat token
        public void Initialize(HeatToken heatToken)
        {
            // Initialize the token element
            base.Initialize(heatToken);
        }

        // Initialize the data given the tokenId
        public void Initialize(string tokenId)
        {
            // Initialize the token element
            base.Initialize(tokenId, TokenType.HEAT);
        }
    }
}