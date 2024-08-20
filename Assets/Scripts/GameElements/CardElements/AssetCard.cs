namespace GameElements
{
    public class AssetCard : CardElement
    {
        // Asset Cards represent the various types of investments and resources
        // that exist in the game. The three main types of assets are: Artifacts,
        // Rackets, and Claims. Assets are attached to either a Location Zone or
        // a Character card and provide various benefits to the player.

        public AssetType assetType;
        public string[] tags;
        public string[] abilities;
        public int coinCost;

        // Initialize the data given an existing asset card
        public void Initialize(AssetCard assetCard)
        {
            // Initialize the card element
            base.Initialize(assetCard);

            // Initialize the asset card
            assetType = assetCard.assetType;
            tags = assetCard.tags;
            abilities = assetCard.abilities;
            coinCost = assetCard.coinCost;
        }

        // Initialize the data given the cardId, cardType, cardName, cardPicture, assetType, tags, abilities, and coinCost
        public void Initialize(string cardId, CardType cardType, string cardName, Sprite cardPicture, AssetType assetType, string[] tags, string[] abilities, int coinCost)
        {
            // Initialize the card element
            base.Initialize(cardId, cardType, cardName, cardPicture);

            // Initialize the asset card
            this.assetType = assetType;
            this.tags = tags;
            this.abilities = abilities;
            this.coinCost = coinCost;
        }
    }

    public enum AssetType
    {
        ARTIFACT,
        RACKET,
        CLAIM
    }
}