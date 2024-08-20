namespace GameElements
{
    public class ProgressToken : TokenElement
    {
        // Progress Tokens are used to track the progress of a goal
        // or the development of an asset.

        // Initialize the data given an existing progress token
        public void Initialize(ProgressToken progressToken)
        {
            // Initialize the token element
            base.Initialize(progressToken);
        }

        // Initialize the data given the tokenId
        public void Initialize(string tokenId)
        {
            // Initialize the token element
            base.Initialize(tokenId, TokenType.PROGRESS);
        }
    }
}