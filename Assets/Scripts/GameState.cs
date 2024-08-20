using System.Collections.Generic;
using GameElements;
using UnityEngine;

namespace GameStates
{
    public class GameState
    {
        public string gameId { get; set; }
        public List<PlayerElement> players { get; set; }
        public List<AreaElement> areas { get; set; }

        // Load the game state from a JSON file
        public static GameState Load(string path)
        {
            Debug.Log("Loading game state from JSON file: " + path);
            string json = System.IO.File.ReadAllText(path);
            return JsonUtility.FromJson<GameState>(json);
        }
    }

    public class ClientGameState
    {
        public string gameId { get; set; }
        public List<PlayerElement> players { get; set; }
        public List<AreaElement> areas { get; set; }
    }
}