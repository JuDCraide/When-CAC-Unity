using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Based on https://discussions.unity.com/t/how-do-i-get-into-the-data-returned-from-a-unitywebrequest/218510/2
// And https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity

[Serializable]
public class Game {
    public string uuid;
    public int latestEp;
    public string seed;
}

public class GetGame : MonoBehaviour {
    // Where to send our request
    const string DEFAULT_URL = "http://localhost:3000/api/game";
    string seed;// = "eyJsYXRlc3RfZXAiOjE3MzYsInN0YXJ0X3RpbWVzdGFtcCI6MTc0NjMxODA0MTQzM30=";
    string targetUrl = DEFAULT_URL;

    // Keep track of what we got back
    string recentData = "";

    void Awake() {
        if (!String.IsNullOrEmpty(this.seed)) {
            targetUrl += $"?seed={this.seed}";
        }
        this.StartCoroutine(this.RequestRoutine(this.targetUrl, this.ResponseCallback));
    }

    // Web requests are typially done asynchronously, so Unity's web request system
    // returns a yield instruction while it waits for the response.
    //
    private IEnumerator RequestRoutine(string url, Action<string> callback = null) {
        // Using the static constructor
        var request = UnityWebRequest.Get(url);

        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        var data = request.downloadHandler.text;

        // This isn't required, but I prefer to pass in a callback so that I can
        // act on the response data outside of this function
        if (callback != null)
            callback(data);
    }

    // Callback to act on our response data
    private void ResponseCallback(string data) {
        Debug.Log(data);
        recentData = data;
        Game g = JsonUtility.FromJson<Game>(data);
        Debug.Log(g.uuid);
        Debug.Log(g.latestEp);
        Debug.Log(g.seed);
    }
}