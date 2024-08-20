using UnityEngine;

namespace GameElements
{
    public abstract class AreaElement : GameElement
    {
        // The Area Element is the base class for all area game elements
        // which are essentially a collection of zones which hold cards and tokens

        public AreaType areaType;
        public string areaName;
        public string ownerId;

        // Initialize the data given an existing area element
        public void Initialize(AreaElement areaElement)
        {
            // Initialize the game element
            base.Initialize(areaElement.id, areaElement.elementType);

            // Initialize the area element
            areaType = areaElement.areaType;
            areaName = areaElement.areaName;
            ownerId = areaElement.ownerId;
        }

        // Initialize the data given the subType and areaName and ownerId
        public void Initialize(AreaType type, string areaName, string ownerId = "GAME")
        {
            // Initialize the game element
            base.Initialize(ElementType.AREA);

            // Initialize the area element
            this.areaType = type;
            this.areaName = areaName;
            this.ownerId = ownerId;
        }
    }

    public enum AreaType
    {
        CALENDAR,
        REPERTOIRE,
        TURF,
        DISTRICT
    }
}