namespace GameElements
{
    public class LocationCard : CardElement
    {
        // Location Cards are cards that represent locations in the game.
        // There are three types of locations: Lairs, Hunting Grounds, and
        // Markets. Locations are attached to a Location Zone and generally
        // provide Actions Spots and Innate Defensive traits.

        public LocationType locationType;
        public string[] tags;
        public string[] abilities;

        // Initialize the data given an existing location card
        public void Initialize(LocationCard locationCard)
        {
            // Initialize the card element
            base.Initialize(locationCard);

            // Initialize the location card
            locationType = locationCard.locationType;
            tags = locationCard.tags;
            abilities = locationCard.abilities;
        }

        // Initialize the data given the cardId, cardType, cardName, cardPicture, locationType, tags, and abilities
        public void Initialize(string cardId, CardType cardType, string cardName, Sprite cardPicture, LocationType locationType, string[] tags, string[] abilities)
        {
            // Initialize the card element
            base.Initialize(cardId, cardType, cardName, cardPicture);

            // Initialize the location card
            this.locationType = locationType;
            this.tags = tags;
            this.abilities = abilities;
        }
    }

    public enum LocationType
    {
        LAIR,
        HUNTING_GROUND,
        MARKET
    }
}