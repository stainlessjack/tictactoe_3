namespace GameElements
{
    public class IdentityCard : CardElement
    {
        // Identity Cards are cards that represent the identities of Crews and Factions.
        // Generally they provide a passive ability to the Crew or Faction that owns them,
        // as well as deck building restrictions for players.

        public string[] tags;
        public string[] abilities;

        // Initialize the data given an existing identity card
        public void Initialize(IdentityCard identityCard)
        {
            // Initialize the card element
            base.Initialize(identityCard);

            // Initialize the identity card
            tags = identityCard.tags;
            abilities = identityCard.abilities;
        }

        // Initialize the data given the cardId, cardType, cardName, cardPicture, tags, and abilities
        public void Initialize(string cardId, CardType cardType, string cardName, Sprite cardPicture, string[] tags, string[] abilities)
        {
            // Initialize the card element
            base.Initialize(cardId, cardType, cardName, cardPicture);

            // Initialize the identity card
            this.tags = tags;
            this.abilities = abilities;
        }
    }

    public enum IdentityType
    {
        CREW,
        FACTION
    }
}