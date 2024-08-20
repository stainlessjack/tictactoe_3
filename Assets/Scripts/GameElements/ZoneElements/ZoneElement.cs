using UnityEngine;

namespace GameElements
{
    public abstract class ZoneElement : GameElement
    {
        // The Zone Element is the base class for all zone game elements
        // which are essentially a collection of cards and tokens

        public ZoneType zoneType;
        public string zoneName;

        // Initialize the data given an existing zone element
        public void Initialize(ZoneElement zoneElement)
        {
            // Initialize the game element
            base.Initialize(zoneElement.id, zoneElement.elementType);

            // Initialize the zone element
            zoneType = zoneElement.zoneType;
            zoneName = zoneElement.zoneName;
        }

        // Initialize the data given the subType and zoneName
        public void Initialize(ZoneType type, string zoneName)
        {
            // Initialize the game element
            base.Initialize(ElementType.ZONE);

            // Initialize the zone element
            this.zoneType = type;
            this.zoneName = zoneName;
        }
    }

    public enum ZoneType
    {
        // type used for the players hands
        HAND,
        // type used for deck behavior
        DECK,
        // type used for typical card pile behavior
        DISCARD,
        // type used for the Obstacle and Asset zones
        PLAY,
        // type used for various zones that are primarily defined by tokens
        TOKEN,
        // type used for various zones typically defined by a single card (Location and Identity zones)
        PERMANENT,
        // type used for action spots where characters can be placed
        ACTION
    }
}