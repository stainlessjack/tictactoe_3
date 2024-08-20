namespace GameElements
{
    public class InformationCard : CardElement
    {
        // Information Cards come in the form of Plans and Details. They are used to
        // perform a Score action. Plans are found in a Crew's Deck and Details are
        // found in the Opportunity Decks of each Faction. A Plan and Detail must
        // have matching Need symbols to be used together.

        public string[] tags;
        public InformationType informationType;
        public string[] requirements;
        public string[] targets;
        public string[] abilities;
        public string[] rewards;
        public string need;

        // Initialize the data given an existing information card
        public void Initialize(InformationCard informationCard)
        {
            // Initialize the card element
            base.Initialize(informationCard);

            // Initialize the information card
            tags = informationCard.tags;
            informationType = informationCard.informationType;
            requirements = informationCard.requirements;
            targets = informationCard.targets;
            abilities = informationCard.abilities;
            rewards = informationCard.rewards;
            need = informationCard.need;
        }

        // Initialize the data given the cardId, cardType, cardName, cardPicture, tags, informationType, requirements, targets, abilities, rewards, and need
        public void Initialize(string cardId, CardType cardType, string cardName, Sprite cardPicture, string[] tags, InformationType informationType, string[] requirements, string[] targets, string[] abilities, string[] rewards, string need)
        {
            // Initialize the card element
            base.Initialize(cardId, cardType, cardName, cardPicture);

            // Initialize the information card
            this.tags = tags;
            this.informationType = informationType;
            this.requirements = requirements;
            this.targets = targets;
            this.abilities = abilities;
            this.rewards = rewards;
            this.need = need;
        }
    }

    public enum InformationType
    {
        PLAN,
        DETAIL
    }
}