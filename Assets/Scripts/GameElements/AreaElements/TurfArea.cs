namespace GameElements
{
    public class TurfArea : AreaElement
    {
        // The Turf Area is the area where the player can see all the cards
        // in their turf (essentially the player's play area).  The player
        // can drag cards to this area to prep them.

        public PermanentZone identityZone;
        public PermanentZone huntingGroundsZone;
        public PermanentZone lairZone;
        public ActionZone lairActionZone;
        public ActionZone huntingGroundsActionZone;
        public DeckZone crewDeck;
        public PlayZone lairObstacleZone;
        public PlayZone huntingGroundsObstacleZone;
        public PlayZone lairAssetZone;
        public PlayZone huntingGroundsAssetZone;
        public TokenZone coinZone;
        public TokenZone heatZone;
        public TokenZone reputationZone;

        // Initialize the data given an existing turf area
        public void Initialize(TurfArea turfArea)
        {
            // Initialize the area element
            base.Initialize(turfArea);

            // Initialize the turf area
            identityZone.Initialize(turfArea.identityZone);
            huntingGroundsZone.Initialize(turfArea.huntingGroundsZone);
            lairZone.Initialize(turfArea.lairZone);
            lairActionZone.Initialize(turfArea.lairActionZone);
            huntingGroundsActionZone.Initialize(turfArea.huntingGroundsActionZone);
            crewDeck.Initialize(turfArea.crewDeck);
            lairObstacleZone.Initialize(turfArea.lairObstacleZone);
            huntingGroundsObstacleZone.Initialize(turfArea.huntingGroundsObstacleZone);
            lairAssetZone.Initialize(turfArea.lairAssetZone);
            huntingGroundsAssetZone.Initialize(turfArea.huntingGroundsAssetZone);
            coinZone.Initialize(turfArea.coinZone);
            heatZone.Initialize(turfArea.heatZone);
            reputationZone.Initialize(turfArea.reputationZone);
        }

        // Initialize the data given the ownerId, identityZone, huntingGroundsZone, lairZone,
        // lairActionZone, huntingGroundsActionZone, crewDeck, lairObstacleZone,
        // huntingGroundsObstacleZone, lairAssetZone, huntingGroundsAssetZone, coinZone,
        // heatZone, and reputationZone
        public void Initialize(string ownerId, PermanentZone identityZone, PermanentZone huntingGroundsZone, PermanentZone lairZone,
            ActionZone lairActionZone, ActionZone huntingGroundsActionZone, DeckZone crewDeck, PlayZone lairObstacleZone,
            PlayZone huntingGroundsObstacleZone, PlayZone lairAssetZone, PlayZone huntingGroundsAssetZone, TokenZone coinZone,
            TokenZone heatZone, TokenZone reputationZone)
        {
            // Initialize the area element with the areaName set to ownerId + "_Turf"
            base.Initialize(AreaType.TURF, ownerId + "_Turf", ownerId);

            // Initialize the turf area
            this.identityZone.Initialize(identityZone);
            this.huntingGroundsZone.Initialize(huntingGroundsZone);
            this.lairZone.Initialize(lairZone);
            this.lairActionZone.Initialize(lairActionZone);
            this.huntingGroundsActionZone.Initialize(huntingGroundsActionZone);
            this.crewDeck.Initialize(crewDeck);
            this.lairObstacleZone.Initialize(lairObstacleZone);
            this.huntingGroundsObstacleZone.Initialize(huntingGroundsObstacleZone);
            this.lairAssetZone.Initialize(lairAssetZone);
            this.huntingGroundsAssetZone.Initialize(huntingGroundsAssetZone);
            this.coinZone.Initialize(coinZone);
            this.heatZone.Initialize(heatZone);
            this.reputationZone.Initialize(reputationZone);
        }
    }
}