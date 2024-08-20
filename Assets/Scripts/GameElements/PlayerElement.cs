using UnityEngine;

namespace GameElements
{
    public class PlayerElement : GameElement
    {
        // The player's ID
        public string playerId;
        // The player's name
        public string playerName;
        // The player's profile picture
        public Sprite playerPicture;
        // The player's reputation
        public int playerReputation;

        // Initialize the player element
        public void Initialize(PlayerElement player)
        {
            // Set the game element's ID and type
            Initialize(player.id, player.elementType);
            // Set the player's ID
            playerId = player.playerId;
            // Set the player's name
            playerName = player.playerName;
            // Set the player's profile picture
            playerPicture = player.playerPicture;
            // Set the player's reputation
            playerReputation = player.playerReputation;
        }

        // Initialize the player element with the data given from the matchmaker
        public void Initialize(string playerId, string playerName, Sprite playerPicture)
        {
            // Generate a new ID for the player element
            Initialize(ElementType.PLAYER);
            // Set the player's ID
            this.playerId = playerId;
            // Set the player's name
            this.playerName = playerName;
            // Set the player's profile picture
            this.playerPicture = playerPicture;
            // Set the player's reputation to 0 by default
            playerReputation = 0;
        }

        // Initialize with just the player's ID
        // TODO: Decide if I should get the player's name and pic from the database here or in the matchmaker
    }
}