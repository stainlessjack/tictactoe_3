namespace GameElements
{
    public class DeckZone : ZoneElement
    {
        // The Deck Zone is a zone that represents a deck of cards

        public List<CardElement> cards;

        // Initialize the data given an existing deck zone
        public void Initialize(DeckZone deckZone)
        {
            // Initialize the zone element
            base.Initialize(deckZone);

            // Initialize the deck zone
            cards = new List<CardElement>(deckZone.cards);
        }

        // Initialize the data given the zoneName and ownerId
        public void Initialize(string zoneName, string ownerId)
        {
            // Initialize the zone element
            base.Initialize(ZoneType.DECK, zoneName);

            // Initialize the deck zone
            cards = new List<CardElement>();
        }
    }
}