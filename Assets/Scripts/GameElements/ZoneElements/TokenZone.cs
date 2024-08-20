namespace GameElements
{
    public class TokenZone : ZoneElement
    {
        // The Token Zone is a zone where tokens are placed and removed

        public Dictionary<TokenType, int> tokens;

        // Initialize the data given an existing token zone
        public void Initialize(TokenZone tokenZone)
        {
            // Initialize the zone element
            base.Initialize(tokenZone);

            // Initialize the token zone
            tokens = new Dictionary<TokenType, int>(tokenZone.tokens);
        }

        // Initialize the data given the zone name
        public void Initialize(string zoneName)
        {
            // Initialize the zone element
            base.Initialize(ZoneType.TOKEN, zoneName);

            // Initialize the token zone
            tokens = new Dictionary<TokenType, int>();
        }
    }
}