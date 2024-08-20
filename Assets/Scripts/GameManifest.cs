namespace ReleaseManager {
    [System.Serializable]
    public class GameManifest {
        public string gameVersion;
        public string gameConnectURL;
        public string gameDownloadURL;
        public GameFile[] gameFiles;
    }

    [System.Serializable]
    public class GameFile {
        public string gameFileName;
        public string gameFileSize;
        public string gameFileSHA256;
    }
}
