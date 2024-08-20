using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetworkSettings{
    public class NetworkClient : MonoBehaviour
    {
        public string gameVersion = Application.version;
        public string gameConnectURL = "http://144.202.111.41:8000";
        public string gameDownloadURL = "http://144.202.111.41:8080/active";
    }
}