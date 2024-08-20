namespace GameElements
{
    public class HandZone : ZoneElement
    {
        // The Hand Zone is a zone that represents a player's hand of cards

        public List<CardElement> cards;

        // Initialize the data given an existing hand zone
        public void Initialize(HandZone handZone)
        {
            // Initialize the zone element
            base.Initialize(handZone);

            // Initialize the hand zone
            cards = new List<CardElement>(handZone.cards);
        }

        // Initialize the data given the zoneName and ownerId
        public void Initialize(string zoneName, string ownerId)
        {
            // Initialize the zone element
            base.Initialize(ZoneType.HAND, zoneName);

            // Initialize the hand zone
            cards = new List<CardElement>();
        }
    }
}