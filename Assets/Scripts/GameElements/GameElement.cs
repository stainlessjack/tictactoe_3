using System.Collections.Generic;
using UnityEngine;

namespace GameElements
{
    // Base class for all game elements
    public abstract class GameElement : MonoBehaviour
    {
        // ID of the game element, used for referencing it in the game state data
        public string id;

        // The type of game element (Player, Area, Zone, Card, Token, etc.)
        public ElementType elementType;

        // Sets the game element's ID and type
        public void Initialize(string elementId, ElementType type)
        {
            id = elementId;
            elementType = type;
        }

        // Sets the game element's type and generates a unique ID for it
        public void Initialize(ElementType type)
        {
            elementType = type;
            id = elementType.ToString() + "_" + System.Guid.NewGuid().ToString();
        }
    }

    public enum ElementType
    {
        PLAYER,
        AREA,
        ZONE,
        CARD,
        TOKEN
    }
}