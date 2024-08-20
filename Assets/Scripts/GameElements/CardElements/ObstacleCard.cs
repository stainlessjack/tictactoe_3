namespace GameElements
{
    public class ObstacleCard : CardElement
    {
        // Obstacle Cards are cards that represent a location's defenses and generally increase
        // the difficulty of a score. Obstacles are of the subtypes: Enforcer, Ward, Cipher, and
        // Hazard.

        public ObstacleType obstacleType;
        public string[] tags;
        public int coinCost;
        public string[] path0Requirements;
        public string[] path1Requirements;
        public string[] path0Effects;
        public string[] path1Effects;

        // Initialize the data given an existing obstacle card
        public void Initialize(ObstacleCard obstacleCard)
        {
            // Initialize the card element
            base.Initialize(obstacleCard);

            // Initialize the obstacle card
            obstacleType = obstacleCard.obstacleType;
            tags = obstacleCard.tags;
            coinCost = obstacleCard.coinCost;
            path0Requirements = obstacleCard.path0Requirements;
            path1Requirements = obstacleCard.path1Requirements;
            path0Effects = obstacleCard.path0Effects;
            path1Effects = obstacleCard.path1Effects;
        }

        // Initialize the data given the cardId, cardType, cardName, cardPicture, obstacleType, tags, coinCost, path0Requirements, path1Requirements, path0Effects, and path1Effects
        public void Initialize(string cardId, CardType cardType, string cardName, Sprite cardPicture, ObstacleType obstacleType, string[] tags, int coinCost, string[] path0Requirements, string[] path1Requirements, string[] path0Effects, string[] path1Effects)
        {
            // Initialize the card element
            base.Initialize(cardId, cardType, cardName, cardPicture);

            // Initialize the obstacle card
            this.obstacleType = obstacleType;
            this.tags = tags;
            this.coinCost = coinCost;
            this.path0Requirements = path0Requirements;
            this.path1Requirements = path1Requirements;
            this.path0Effects = path0Effects;
            this.path1Effects = path1Effects;
        }
    }

    public enum ObstacleType
    {
        ENFORCER,
        WARD,
        CIPHER,
        HAZARD
    }
}