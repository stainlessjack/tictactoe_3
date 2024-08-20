using UnityEngine;
using System.Collections;
using GameStates;
using GameElements;
using System.Collections.Generic;

public class Scene2Manager : MonoBehaviour
{
    // The Scene Manager is the main controller for initializing the game state and
    // controlling the flow of play, as well as translating the game state
    // into the GameObjects that are displayed in the scene. It is also responsible
    // for handling user input and translating that into changes to the game state.

    // The authoritative game state data
    private GameState gameState;

    // The list of area objects in the game
    public GameObject calendarArea;
    public GameObject p1RepertoireArea;
    public GameObject p2RepertoireArea;
    public GameObject p1TurfArea;
    public GameObject p2TurfArea;
    public GameObject institutionDistrictArea;
    public GameObject laborandtradeDistrictArea;
    public GameObject underworldDistrictArea;
    public GameObject theFringeDistrictArea;

    // The player object in the game
    public GameObject p1Player;

    // The bot player object in the game
    public GameObject p2Player;

    void Start()
    {
        // Initialize the game state
        gameState = LoadInitialGameState();

        // Initialize the player and area objects in the game
        InitializeGameObjects(gameState);
    }

    private GameState LoadInitialGameState()
    {
        // Load the default initial game state from a JSON file
        GameState gameState = GameState.Load("Assets/Resources/GameStates/DefaultInitialGameState.json");

        // Return the loaded game state
        return gameState;
    }

    private void InitializeGameObjects(GameState gameState)
    {
        // Assign data to the PlayerElements
        p1Player.GetComponent<PlayerElement>().Initialize(gameState.players[0]);
        p2Player.GetComponent<PlayerElement>().Initialize(gameState.players[1]);

        // Assign data to the AreaElements
        foreach (AreaElement area in gameState.areas)
        {
            switch(area.areaType)
            {
                case AreaType.CALENDAR:
                    calendarArea.GetComponent<AreaElement>().Initialize(area);
                    break;
                case AreaType.REPERTOIRE:
                    if (area.ownerId == p1Player.GetComponent<PlayerElement>().id)
                    {
                        p1RepertoireArea.GetComponent<AreaElement>().Initialize(area);
                    }
                    else if (area.ownerId == p2Player.GetComponent<PlayerElement>().id)
                    {
                        p2RepertoireArea.GetComponent<AreaElement>().Initialize(area);
                    }
                    break;
                case AreaType.TURF:
                    if (area.ownerId == p1Player.GetComponent<PlayerElement>().id)
                    {
                        p1TurfArea.GetComponent<AreaElement>().Initialize(area);
                    }
                    else if (area.ownerId == p2Player.GetComponent<PlayerElement>().id)
                    {
                        p2TurfArea.GetComponent<AreaElement>().Initialize(area);
                    }
                    break;
                case AreaType.DISTRICT:
                    if (area.areaName == "InstitutionBoard")
                    {
                        institutionDistrictArea.GetComponent<AreaElement>().Initialize(area);
                    }
                    else if (area.areaName == "LaborAndTradeBoard")
                    {
                        laborandtradeDistrictArea.GetComponent<AreaElement>().Initialize(area);
                    }
                    else if (area.areaName == "UnderworldBoard")
                    {
                        underworldDistrictArea.GetComponent<AreaElement>().Initialize(area);
                    }
                    else if (area.areaName == "TheFringeBoard")
                    {
                        theFringeDistrictArea.GetComponent<AreaElement>().Initialize(area);
                    }
                    break;
            }
        }
    }
}