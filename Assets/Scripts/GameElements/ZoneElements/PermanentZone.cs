namespace GameElements
{
    public class PermanentZone : ZoneElement
    {
        // The Permanent Zone is a zone that represents a permanent card

        public CardElement card;

        // Initialize the data given an existing permanent zone
        public void Initialize(PermanentZone permanentZone)
        {
            // Initialize the zone element
            base.Initialize(permanentZone);

            // Initialize the permanent zone
            if (permanentZone.card != null)
            {
                card = permanentZone.card;
            }
        }

        // Initialize the data given the zoneName, ownerId, and card
        public void Initialize(string zoneName, CardElement card)
        {
            // Initialize the zone element
            base.Initialize(ZoneType.PERMANENT, zoneName);

            // Initialize the permanent zone
            this.card = card;
        }
    }
}