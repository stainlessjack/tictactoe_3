using UnityEditor;
using System.Security.Cryptography;
using UnityEngine;
using System.Linq;
using ReleaseManager;
using NetworkSettings;

public class GameBuilder
{
    public static void BuildMacOS()
    {
        var version = PlayerSettings.bundleVersion;
        var versionArray = version.Split('.');
        if(int.Parse(versionArray[2]) < 99){
            versionArray[2] = (int.Parse(versionArray[2]) + 1).ToString();
        }else{
            versionArray[2] = "0";
            if(int.Parse(versionArray[1]) < 99){
                versionArray[1] = (int.Parse(versionArray[1]) + 1).ToString();
            }else{
                versionArray[1] = "0";
                versionArray[0] = (int.Parse(versionArray[0]) + 1).ToString();
            }
        }
        PlayerSettings.bundleVersion = string.Join(".", versionArray);
        BuildPipeline.BuildPlayer(new string[] { "Assets/Scenes/Scene0.unity" }, "Builds/MacOS/tictactoe", BuildTarget.StandaloneOSX, BuildOptions.None);
    }

    public static void GenerateManifest()
    {
        // Create a new dynamically sized array to store the game files
        GameFile[] gameFilesToSave = new GameFile[0];

        // Loop through all files in the game folder and add the file information to the manifest
        // Note: Excluding the manifest and .DS_Store files
        string[] gameFiles = System.IO.Directory.GetFiles(Application.dataPath, "*.*", System.IO.SearchOption.AllDirectories);
        Debug.Log("Looking for files in: " + Application.dataPath);
        foreach (string gameFile in gameFiles)
        {
            // Skip the manifest file
            if (gameFile.EndsWith(".manifest") || gameFile.EndsWith(".DS_Store"))
                continue;

            // Generate the hash for the file
            string hash = GenerateHash(gameFile);

            // Get the file size
            string size = new System.IO.FileInfo(gameFile).Length.ToString();

            GameFile gameFileObject = new GameFile();
            // Determine the relative file path to store
            gameFileObject.gameFileName = gameFile.Replace(Application.dataPath, "");
            gameFileObject.gameFileSize = size;
            gameFileObject.gameFileSHA256 = hash;

            // Add the file to a gameFilesToSave array
            Debug.Log("Adding file to manifest: " + gameFile + ", using representation: " + gameFileObject.gameFileName + ", " + gameFileObject.gameFileSize + ", " + gameFileObject.gameFileSHA256);
            gameFilesToSave = gameFilesToSave.Concat(new GameFile[] { gameFileObject }).ToArray();
        }

        // Create a new GameManifest object
        GameManifest gameManifest = new GameManifest();

        // Set the manifest version
        gameManifest.gameVersion = PlayerSettings.bundleVersion;

        // Set the manifest connect URL
        NetworkClient networkClient = new NetworkClient();
        gameManifest.gameConnectURL = networkClient.gameConnectURL;

        // Set the manifest download URL
        gameManifest.gameDownloadURL = networkClient.gameDownloadURL;

        // Set the manifest game files
        gameManifest.gameFiles = gameFilesToSave;

        // Save the manifest as a JSON file to the project's root directory
        string json = JsonUtility.ToJson(gameManifest, true);
        Debug.Log("Saving manifest: " + json);
        System.IO.File.WriteAllText(Application.dataPath + "/../game.manifest", json);
    }

    private static string GenerateHash(string filePath)
    {
        using (var sha256 = SHA256.Create())
        {
            using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open))
            {
                return System.BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", "").ToLower();
            }
        }
    }
}