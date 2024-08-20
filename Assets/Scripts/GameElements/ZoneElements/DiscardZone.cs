namespace GameElements
{
    public class DiscardZone : ZoneElement
    {
        // The Discard Zone is a zone that represents a discard pile of cards

        public List<CardElement> cards;

        // Initialize the data given an existing discard zone
        public void Initialize(DiscardZone discardZone)
        {
            // Initialize the zone element
            base.Initialize(discardZone);

            // Initialize the discard zone
            cards = new List<CardElement>(discardZone.cards);
        }

        // Initialize the data given the zoneName and ownerId
        public void Initialize(string zoneName, string ownerId)
        {
            // Initialize the zone element
            base.Initialize(ZoneType.DISCARD, zoneName);

            // Initialize the discard zone
            cards = new List<CardElement>();
        }
    }
}