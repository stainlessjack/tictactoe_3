namespace GameElements
{
    public class EventCard : CardElement
    {
        // An Event Card is a card that represents a singular event in the game.
        // Events are of the subtypes: Day, Ambition, Vice, and Ability.

        public EventType eventType;
        public string[] tags;
        public string[] abilities;
        public string[] requirements;
        public int coinCost;

        // Initialize the data given an existing event card
        public void Initialize(EventCard eventCard)
        {
            // Initialize the card element
            base.Initialize(eventCard);

            // Initialize the event card
            eventType = eventCard.eventType;
            tags = eventCard.tags;
            abilities = eventCard.abilities;
            requirements = eventCard.requirements;
            coinCost = eventCard.coinCost;
        }

        // Initialize the data given the cardId, cardType, cardName, cardPicture, eventType, tags, abilities, requirements, and coinCost
        public void Initialize(string cardId, CardType cardType, string cardName, Sprite cardPicture, EventType eventType, string[] tags, string[] abilities, string[] requirements, int coinCost)
        {
            // Initialize the card element
            base.Initialize(cardId, cardType, cardName, cardPicture);

            // Initialize the event card
            this.eventType = eventType;
            this.tags = tags;
            this.abilities = abilities;
            this.requirements = requirements;
            this.coinCost = coinCost;
        }
    }

    public enum EventType
    {
        DAY,
        AMBITION,
        VICE,
        ABILITY
    }
}