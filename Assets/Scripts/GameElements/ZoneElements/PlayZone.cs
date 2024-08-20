namespace GameElements
{
    public class PlayZone : ZoneElement
    {
        // The Play Zone is a zone where cards are played or moved to
        // and remain in play until discarded or removed

        public List<CardElement> cards;

        // Initialize the data given an existing play zone
        public void Initialize(PlayZone playZone)
        {
            // Initialize the zone element
            base.Initialize(playZone);

            // Initialize the play zone
            cards = new List<CardElement>(playZone.cards);
        }

        // Initialize the data given the zone name
        public void Initialize(string zoneName)
        {
            // Initialize the zone element
            base.Initialize(ZoneType.PERMANENT, zoneName);

            // Initialize the play zone
            cards = new List<CardElement>();
        }
    }
}