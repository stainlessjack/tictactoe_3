namespace GameElements
{
    public class ActionZone : ZoneElement
    {
        // The Action Zone is a zone that is used for placing characters
        // in order to perform actions

        public string parentLocationId;
        public ActionType actionType;
        public CardElement characterCard;

        // Initialize the data given an existing action zone
        public void Initialize(ActionZone actionZone)
        {
            // Initialize the zone element
            base.Initialize(actionZone);

            // Initialize the action zone
            parentLocationId = actionZone.parentLocationId;
            actionType = actionZone.actionType;
            if (actionZone.characterCard != null)
            {
                characterCard = actionZone.characterCard;
            }
        }

        // Initialize the data given the parent location id and action type
        public void Initialize(string parentLocationId, ActionType actionType)
        {
            // Initialize the zone element
            base.Initialize(ZoneType.ACTION, actionType.ToString());

            // Initialize the action zone
            this.parentLocationId = parentLocationId;
            this.actionType = actionType;
            characterCard = null;
        }
    }
}