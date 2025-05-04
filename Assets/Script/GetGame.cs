using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Based on https://discussions.unity.com/t/how-do-i-get-into-the-data-returned-from-a-unitywebrequest/218510/2
// And https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity

[Serializable]
public class InitGame {
    public string uuid;
    public int latestEp;
    public string seed;
}

public class GetGame : MonoBehaviour {
    // Where to send our request
    string seed;// = "eyJsYXRlc3RfZXAiOjE3MzYsInN0YXJ0X3RpbWVzdGFtcCI6MTc0NjMxODA0MTQzM30=";
    string targetUrl = Request.DEFAULT_URL;

    // Keep track of what we got back
    string recentData = "";

    void Awake() {
        if (!String.IsNullOrEmpty(this.seed)) {
            targetUrl += $"?seed={this.seed}";
        }
        this.StartCoroutine(Request.GetRequestRoutine(this.targetUrl, this.ResponseCallback));
    }

    // Callback to act on our response data
    private void ResponseCallback(string data) {
        Debug.Log(data);
        recentData = data;
        InitGame g = JsonUtility.FromJson<InitGame>(data);
        Debug.Log(g.uuid);
        Debug.Log(g.latestEp);
        Debug.Log(g.seed);
    }
}