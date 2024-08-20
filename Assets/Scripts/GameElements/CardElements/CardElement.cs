using UnityEngine;

namespace GameElements
{
    public abstract class CardElement : GameElement
    {
        // The Card Element is the base class for all card game elements

        public string cardID;
        public CardType cardType;
        public string cardName;
        public Sprite cardPicture;

        // Initialize the data given an existing card element
        public void Initialize(CardElement cardElement)
        {
            // Initialize the game element
            base.Initialize(cardElement.id, cardElement.elementType);

            // Initialize the card element
            cardID = cardElement.cardID;
            cardType = cardElement.cardType;
            cardName = cardElement.cardName;
            cardPicture = cardElement.cardPicture;
        }

        // Initialize the data given the cardId, cardType, cardName, and cardPicture
        public void Initialize(string cardId, CardType cardType, string cardName, Sprite cardPicture)
        {
            // Initialize the game element
            base.Initialize(ElementType.CARD);

            // Initialize the card element
            this.cardID = cardId;
            this.cardType = cardType;
            this.cardName = cardName;
            this.cardPicture = cardPicture;
        }
    }

    public enum CardType
    {
        EVENT,
        IDENTITY,
        LOCATION,
        CHARACTER,
        ASSET,
        OBSTACLE,
        INFORMATION
    }
}