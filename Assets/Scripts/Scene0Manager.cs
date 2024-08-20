using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using ReleaseManager;
using NetworkSettings;

public class Scene0Manager : MonoBehaviour
{
    [Serializable]
    public class User
    {
        public string username;
        public string password;
        public string email;
        public string token;
    }

    [Serializable]
    public class LoginResponse
    {
        public string token;
    }

    [SerializeField] private string[] backgroundImagePaths;
    [SerializeField] private GameObject backgroundImage;
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private GameObject loadingText;
    [SerializeField] private GameObject loadingBar;

    public User user;
    private string storedUsername;
    private string storedPassword;
    private bool isServerOnline = false;

    void Start()
    {
        Debug.Log("Starting Scene 0");
        // Start background slide show
        StartCoroutine(BackgroundSlideShow());

        // Check for server availability
        // If server is available, download game manifest
        // If server is not available, load local game manifest
        // If local game manifest is not available, advise user to connect to the internet
        StartCoroutine(AcquireGameManifest());

        // Check to see if user has stored credentials
        // If user has stored credentials, attempt to login
        // If user does not have stored credentials, advise user to login, create an account, or continue as a guest
        StartCoroutine(AcquireUserCredentials());

    }

// TODO Prompt for overwriting/deleting install
    private IEnumerator AcquireUserCredentials()
    {
        // Check to see if user has stored credentials
        storedUsername = PlayerPrefs.GetString("username");
        storedPassword = PlayerPrefs.GetString("password");

        if (isServerOnline)
        {
            // If user has stored credentials, attempt to login
            if (storedUsername != "" && storedPassword != "")
            {
                // Attempt to login
                Debug.Log("User has stored credentials, attempting to login.");
                StartCoroutine(AttemptLogin(storedUsername, storedPassword));
                // If login is successful, set credentials and load the main menu
                // If login is unsuccessful, advise user to login, create an account, or continue as a guest
            }
            else
            {
                Debug.Log("User does not have stored credentials");
                yield return null;
                // If user does not have stored credentials, advise user to login, create an account, or continue as a guest
                
            }
            // If user does not have stored credentials, advise user to login, create an account, or continue as a guest
        }
        else
        {
            Debug.Log("Server is offline");
            // If user has stored credentials, pass those along to the next scene
            // If user does not have stored credentials, continue as a guest
        }
    }

    private IEnumerator AttemptLogin(string username, string password)
    {
        // Create server address
        NetworkClient networkClient = new NetworkClient();
        string loginUrl = networkClient.gameConnectURL + "/login";

        // Create the post form request
        var form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        using(UnityWebRequest loginRequest = UnityWebRequest.Post(loginUrl, form))
        {
            // print out the outgoing request
            Debug.Log("Sending request to server: " + loginRequest.url);
            Debug.Log("Request method: " + loginRequest.method);
            yield return loginRequest.SendWebRequest();
            if (loginRequest.result == UnityWebRequest.Result.ConnectionError || loginRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Connection Error: " + loginRequest.error);
            }
            else
            {
                if (loginRequest.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Login successful");
                    // Set user credentials
                    user.username = username;
                    user.password = password;
                    user.token = JsonUtility.FromJson<LoginResponse>(loginRequest.downloadHandler.text).token;
                    PlayerPrefs.SetString("token", user.token);
                    // Load the main menu
                    SceneManager.LoadScene("Scene1");
                }
                else
                {
                    Debug.Log("Login unsuccessful");
                    // Advise user to login, create an account, or continue as a guest
                }
                // If login is successful, set credentials and load the main menu
                // If login is unsuccessful, advise user to login, create an account, or continue as a guest
            }
        }
    }

    private IEnumerator BackgroundSlideShow()
    {
        int backgroundImageIndex = 0;

        while (true)
        {
            // Load background image
            backgroundImage.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(backgroundImagePaths[backgroundImageIndex]);

            // Increment background image index
            if (backgroundImageIndex < backgroundImagePaths.Length - 1)
            {
                backgroundImageIndex++;
            }
            else
            {
                backgroundImageIndex = 0;
            }

            // Slowly fade in the background image, hold for 5 seconds
            for (float i = 0; i <= 1; i += 0.001f)
            {
                backgroundImage.GetComponent<CanvasGroup>().alpha = i;
                if (i == 1)
                {
                    yield return new WaitForSecondsRealtime(5);
                }
                yield return new WaitForSecondsRealtime(0.01f);
            }

            // Slowly fade out the background image
            for (float i = 1; i >= 0; i -= 0.001f)
            {
                if (i == 0)
                {
                    // Clear background image
                    backgroundImage.GetComponent<UnityEngine.UI.Image>().sprite = null;
                    yield return new WaitForSecondsRealtime(1);
                }
                backgroundImage.GetComponent<CanvasGroup>().alpha = i;
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
    }

    private IEnumerator AcquireGameManifest(int numberofattempts = 0)
    {
        loadingUI.SetActive(true);
        loadingText.GetComponent<TMPro.TextMeshProUGUI>().text = "Connecting";

        // Create server address
        NetworkClient networkClient = new NetworkClient();
        string downloadUrl = networkClient.gameDownloadURL + "/game.manifest";
        using(UnityWebRequest gameManifestJSON = UnityWebRequest.Get(downloadUrl))
        {
            // print out the outgoing request
            Debug.Log("Sending request to server: " + gameManifestJSON.url);
            Debug.Log("Request method: " + gameManifestJSON.method);
            yield return gameManifestJSON.SendWebRequest();
            Debug.Log("Response from server: " + gameManifestJSON.GetRequestHeader("Content-Type"));
            if (gameManifestJSON.result == UnityWebRequest.Result.ConnectionError || gameManifestJSON.result == UnityWebRequest.Result.ProtocolError)
            {
                isServerOnline = false;
                Debug.Log(gameManifestJSON.error);
                if (numberofattempts > 5)
                {
                    // Stop checking for server availability
                    // Load local game manifest
                    string gameManifestJSONPath = Application.dataPath + "/game.manifest";
                    if (System.IO.File.Exists(gameManifestJSONPath))
                    {
                        Debug.Log("Local game manifest found");
                        loadingText.GetComponent<TMPro.TextMeshProUGUI>().text = "Continuing Offline";
                        // Parse game manifest
                        GameManifest gameManifest = JsonUtility.FromJson<GameManifest>(System.IO.File.ReadAllText(gameManifestJSONPath));
                        Debug.Log(gameManifest.gameVersion);
                        Debug.Log(gameManifest.gameConnectURL);
                        Debug.Log(gameManifest.gameDownloadURL);
                        StartCoroutine(ValidateInstallation(gameManifest));
                    }
                    else
                    {
                        Debug.Log("Game manifest not found");
                        loadingText.GetComponent<TMPro.TextMeshProUGUI>().text = "Please Reinstall";
                        // Allow user to quit and advise that an internet connection is required
                        // TODO: Add UI to allow user to quit
                    }
                }
                else
                {
                    // Check again in 5 seconds
                    yield return new WaitForSecondsRealtime(5);
                    StartCoroutine(AcquireGameManifest(numberofattempts + 1));
                }
            }
            else
            {
                isServerOnline = true;
                Debug.Log("Server is available");
                Debug.Log("Game manifest downloaded");
                GameManifest gameManifest = JsonUtility.FromJson<GameManifest>(gameManifestJSON.downloadHandler.text);
                Debug.Log(gameManifest.gameVersion);
                Debug.Log(gameManifest.gameConnectURL);
                Debug.Log(gameManifest.gameDownloadURL);
                loadingText.GetComponent<TMPro.TextMeshProUGUI>().text = "Connected";
                StartCoroutine(ValidateInstallation(gameManifest));
            }
        }
    }

    private IEnumerator ValidateInstallation(GameManifest gameManifest)
    {
        List<string> gameFilesToDelete = new List<string>();
        List<string> gameFilesToDownload = new List<string>();

        SHA256 sha256 = SHA256.Create();

        // Check for game directories and correct file hashes
        loadingText.GetComponent<TMPro.TextMeshProUGUI>().text = "Validating Installation";
        foreach (GameFile gameFile in gameManifest.gameFiles)
        {
            string gameFilePath = Application.dataPath + gameFile.gameFileName;
            if (System.IO.File.Exists(gameFilePath))
            {
                Debug.Log("File exists: " + gameFilePath);
                // Check file hash
                byte[] gameFileBytes = System.IO.File.ReadAllBytes(gameFilePath);
                byte[] gameFileHash = sha256.ComputeHash(gameFileBytes);
                string gameFileHashString = BitConverter.ToString(gameFileHash).Replace("-", "").ToLower();
                if (gameFileHashString == gameFile.gameFileSHA256)
                {
                    Debug.Log("File hash is valid for: " + gameFilePath);
                }
                else
                {
                    Debug.Log("File hash is invalid for: " + gameFilePath);
                    gameFilesToDownload.Add(gameFile.gameFileName);
                }
            }
            else
            {
                Debug.Log("File does not exist: " + gameFilePath);
                gameFilesToDownload.Add(gameFile.gameFileName);
            }
        }

        // Check for game files that are not in the game manifest
        string[] localGameFiles = System.IO.Directory.GetFiles(Application.dataPath);
        foreach (string localGameFile in localGameFiles)
        {
            bool gameFileFound = false;
            foreach (GameFile gameFile in gameManifest.gameFiles)
            {
                if (localGameFile == Application.dataPath + gameFile.gameFileName)
                {
                    gameFileFound = true;
                }
            }
            if (!gameFileFound)
            {
                Debug.Log("File not in game manifest: " + localGameFile);
                gameFilesToDelete.Add(localGameFile);
            }
        }

        // Calculate and inform user of download size
        long downloadSize = 0;
        foreach (string gameFileToDownload in gameFilesToDownload)
        {
            foreach (GameFile gameFile in gameManifest.gameFiles)
            {
                if (gameFileToDownload == gameFile.gameFileName)
                {
                    downloadSize += long.Parse(gameFile.gameFileSize);
                }
            }
        }
        Debug.Log("Download size: " + downloadSize);
        
        if (downloadSize > 0)
        {
            loadingText.GetComponent<TMPro.TextMeshProUGUI>().text = "Downloading " + downloadSize + " bytes";
        }
        else
        {
            loadingText.GetComponent<TMPro.TextMeshProUGUI>().text = "Starting Game";
        }

        StartCoroutine(DownloadGameFiles(gameManifest, gameFilesToDownload));
        StartCoroutine(DeleteGameFiles(gameFilesToDelete));
        yield return null;
    }

    private IEnumerator DownloadGameFiles(GameManifest gameManifest, List<string> gameFilesToDownload)
    {
        int numberOfGameFilesDownloaded = 0;
        int numberOfGameFilesToDownload = gameFilesToDownload.Count;
        foreach (string gameFileToDownload in gameFilesToDownload)
        {
            StartCoroutine(DownloadGameFile(gameManifest, gameFileToDownload));
            // Determine download progress
            numberOfGameFilesDownloaded++;

        }
        yield return null;
    }

    private IEnumerator DownloadGameFile(GameManifest gameManifest, string gameFileToDownload, int numberOfAttempts = 0)
    {
        // TODO: Probably wrong, also, add a progress bar
        Debug.Log("Requesting download from: " + gameManifest.gameDownloadURL + "/Assets" + gameFileToDownload);
        using (UnityWebRequest gameFileDownload = UnityWebRequest.Get(gameManifest.gameDownloadURL + "/Assets" + gameFileToDownload))
        {
            yield return gameFileDownload.SendWebRequest();
            if (gameFileDownload.result == UnityWebRequest.Result.ConnectionError || gameFileDownload.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(gameFileDownload.error);
                if (numberOfAttempts < 5)
                {
                    StartCoroutine(DownloadGameFile(gameManifest, gameFileToDownload, numberOfAttempts + 1));
                }
                else
                {
                    Debug.Log("Failed to download game file: " + gameFileToDownload);
                }
            }
            else
            {
                Debug.Log("Game file downloaded: " + gameFileToDownload);
                System.IO.File.WriteAllBytes(Application.dataPath + gameFileToDownload, gameFileDownload.downloadHandler.data);
            }
        }
    }

    private IEnumerator DeleteGameFiles(List<string> gameFilesToDelete)
    {
        foreach (string gameFileToDelete in gameFilesToDelete)
        {
            System.IO.File.Delete(gameFileToDelete);
        }
        yield return null;
    }
}
