namespace GameElements
{
    public abstract class TokenElement : GameElement
    {
        // The Token Element is the base class for all token game elements

        public string tokenId;
        public TokenType tokenType;

        // Initialize the data given an existing token element
        public void Initialize(TokenElement tokenElement)
        {
            // Initialize the game element
            base.Initialize(tokenElement.id, tokenElement.elementType);

            // Initialize the token element
            tokenId = tokenElement.tokenId;
            tokenType = tokenElement.tokenType;
        }

        // Initialize the data given the tokenId and tokenType
        public void Initialize(string tokenId, TokenType tokenType)
        {
            // Initialize the game element
            base.Initialize(ElementType.TOKEN);

            // Initialize the token element
            this.tokenId = tokenId;
            this.tokenType = tokenType;
        }
    }

    public enum TokenType
    {
        STRESS,
        COIN,
        HEAT,
        STATUS,
        PROGRESS,
        TRAUMA
    }
}