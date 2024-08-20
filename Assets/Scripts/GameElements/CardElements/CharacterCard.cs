namespace GameElements
{
    public class CharacterCard : CardElement
    {
        // A Character Card is a card that represents a character in the game.
        // Characters are either Scoundrels, Leaders, or Associates.

        public CharacterType characterType;
        public int coinCost;
        public string[] requirements;
        public string[] tags;
        public string[] skills;
        public string[] abilities;
        public string[] tokenIDs;

        // Initialize the data given an existing character card
        public void Initialize(CharacterCard characterCard)
        {
            // Initialize the card element
            base.Initialize(characterCard);

            // Initialize the character card
            characterType = characterCard.characterType;
            coinCost = characterCard.coinCost;
            tags = characterCard.tags;
            skills = characterCard.skills;
            abilities = characterCard.abilities;
            tokenIDs = characterCard.tokenIDs;
        }

        // Initialize the data given the cardId, cardType, cardName, cardPicture, characterType, coinCost, tags, skills, abilities, and tokenIDs
        public void Initialize(string cardId, CardType cardType, string cardName, Sprite cardPicture, CharacterType characterType, int coinCost, string[] tags, string[] skills, string[] abilities, string[] tokenIDs)
        {
            // Initialize the card element
            base.Initialize(cardId, cardType, cardName, cardPicture);

            // Initialize the character card
            this.characterType = characterType;
            this.coinCost = coinCost;
            this.tags = tags;
            this.skills = skills;
            this.abilities = abilities;
            this.tokenIDs = tokenIDs;
        }
    }

    public enum CharacterType
    {
        SCOUNDREL,
        LEADER,
        ASSOCIATE
    }
}