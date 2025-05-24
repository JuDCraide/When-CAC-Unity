using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Request {
    public const string DEFAULT_URL = "http://localhost:3000/api/game";

    // Web requests are typially done asynchronously, so Unity's web request system
    // returns a yield instruction while it waits for the response.
    static public IEnumerator GetRequestRoutine(string url, Action<string> callback = null) {
        // Using the static constructor
        var request = UnityWebRequest.Get(url);

        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        string data = request.downloadHandler.text;
        long status = request.responseCode;
        //Debug.Log(status);

        if(status / 100 != 2) {
            // Error
        }

        // This isn't required, but I prefer to pass in a callback so that I can
        // act on the response data outside of this function
        else if (callback != null) {
            callback(data);
        }
    }

    static public IEnumerator PostRequestRoutine(string url, string postBody, Action<string> callback = null) {
        // Using the static constructor
        //Debug.Log(url);
        //Debug.Log(postBody);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(postBody);
        //var request = UnityWebRequest.Put(url, bytes);
        var request = new UnityWebRequest(url, "POST", new DownloadHandlerBuffer(), new UploadHandlerRaw(bytes));
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "application/json");

        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        string data = request.downloadHandler.text;
        long status = request.responseCode;
        //Debug.Log(status);

        if (status / 100 != 2) {
            Debug.Log(data);
            // Error
        }

        // This isn't required, but I prefer to pass in a callback so that I can
        // act on the response data outside of this function
        else if (callback != null) {
            callback(data);

        }
    }
}
