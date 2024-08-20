namespace GameElements
{
    public class DistrictArea : AreaElement
    {
        // District Areas are the areas belonging to each of the
        // game's Factions. There will be 4 District Areas in each game.
        public DistrictType districtType;

        public PermanentZone identityZone;
        public PermanentZone locationZone;
        public PlayZone characterZone;
        public ActionZone actionZone;
        public PlayZone obstacleZone;
        public TokenZone statusZone;
        public TokenZone progressClockZone;
        public DeckZone obstacleDeck;
        public DeckZone opportunityDeck;
        public DeckZone assetDeck;

        // Initialize the data given an existing district area
        public void Initialize(DistrictArea districtArea)
        {
            // Initialize the area element
            base.Initialize(districtArea);

            // Initialize the district area
            districtType = districtArea.districtType;
            identityZone.Initialize(districtArea.identityZone);
            locationZone.Initialize(districtArea.locationZone);
            characterZone.Initialize(districtArea.characterZone);
            actionZone.Initialize(districtArea.actionZone);
            obstacleZone.Initialize(districtArea.obstacleZone);
            statusZone.Initialize(districtArea.statusZone);
            progressClockZone.Initialize(districtArea.progressClockZone);
            obstacleDeck.Initialize(districtArea.obstacleDeck);
            opportunityDeck.Initialize(districtArea.opportunityDeck);
            assetDeck.Initialize(districtArea.assetDeck);
        }

        // Initialize the data given the areaName, identityZone, locationZone, characterZone,
        // actionZone, obstacleZone, statusZone, progressClockZone, obstacleDeck,
        // opportunityDeck, and assetDeck
        public void Initialize(string areaName, DistrictType districtType, PermanentZone identityZone, PermanentZone locationZone, PlayZone characterZone,
            ActionZone actionZone, PlayZone obstacleZone, TokenZone statusZone, TokenZone progressClockZone,
            DeckZone obstacleDeck, DeckZone opportunityDeck, DeckZone assetDeck)
        {
            // Initialize the area element
            base.Initialize(AreaType.DISTRICT, areaName, "GAME");

            // Initialize the district area
            this.districtType = districtType;
            this.identityZone.Initialize(identityZone);
            this.locationZone.Initialize(locationZone);
            this.characterZone.Initialize(characterZone);
            this.actionZone.Initialize(actionZone);
            this.obstacleZone.Initialize(obstacleZone);
            this.statusZone.Initialize(statusZone);
            this.progressClockZone.Initialize(progressClockZone);
            this.obstacleDeck.Initialize(obstacleDeck);
            this.opportunityDeck.Initialize(opportunityDeck);
            this.assetDeck.Initialize(assetDeck);
        }
    }

    public enum DistrictType
    {
        INSTITUTION,
        LABOR_AND_TRADE,
        UNDERWORLD,
        THE_FRINGE
    }
}