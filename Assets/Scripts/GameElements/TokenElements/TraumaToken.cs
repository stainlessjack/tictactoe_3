namespace GameElements
{
    public class TraumaToken : TokenElement
    {
        // Trauma Tokens are used to track the trauma of characters.

        // Initialize the data given an existing trauma token
        public void Initialize(TraumaToken traumaToken)
        {
            // Initialize the token element
            base.Initialize(traumaToken);
        }

        // Initialize the data given the tokenId
        public void Initialize(string tokenId)
        {
            // Initialize the token element
            base.Initialize(tokenId, TokenType.TRAUMA);
        }
    }
}