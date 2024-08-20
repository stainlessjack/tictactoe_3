namespace GameElements
{
    public class StressToken : TokenElement
    {
        // Stress Tokens are used to track the stress of characters.

        // Initialize the data given an existing stress token
        public void Initialize(StressToken stressToken)
        {
            // Initialize the token element
            base.Initialize(stressToken);
        }

        // Initialize the data given the tokenId
        public void Initialize(string tokenId)
        {
            // Initialize the token element
            base.Initialize(tokenId, TokenType.STRESS);
        }
    }
}