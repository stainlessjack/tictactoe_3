namespace GameElements
{
    public class RepertoireArea : AreaElement
    {
        // The Repertoire Area is the area where the player can see all the cards
        // in their repertoire (essentially the player's hand of cards).  The player
        // can drag cards from this area to play them.

        public HandZone repertoire;

        // Initialize the data given an existing repertoire area
        public void Initialize(RepertoireArea repertoireArea)
        {
            // Initialize the area element
            base.Initialize(repertoireArea);

            // Initialize the repertoire area
            repertoire = repertoireArea.repertoire;
        }

        // Initialize the data given just the HandZone and ownerId
        public void Initialize(HandZone handZone, string ownerId)
        {
            // Initialize the area element with the areaName set to ownerId + "_Repertoire"
            base.Initialize(AreaType.REPERTOIRE, ownerId + "_Repertoire", ownerId);

            // Initialize the repertoire area
            this.repertoire = handZone;
        }
    }
}