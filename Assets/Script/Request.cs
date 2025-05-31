using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

// This script handles web requests to the server
// Based on https://discussions.unity.com/t/how-do-i-get-into-the-data-returned-from-a-unitywebrequest/218510/2
// And https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
public class Request {
    public const string DEFAULT_URL = "https://when-cac.vercel.app/api/game";
    public const string DEFAULT_URL_TEST = "http://localhost:3000/api/game";
    public const string DEFAULT_URL_STATISTICS = "https://when-cac.vercel.app/api/statistics?origin=";

    // Web requests are typically done asynchronously, so Unity's web request system
    // returns a yield instruction while it waits for the response.
    static public IEnumerator GetRequestRoutine(string url, Action<string> callback = null) {
        // Using the static constructor
        var request = UnityWebRequest.Get(url);
        //request.SetRequestHeader("Access-Control-Allow-Origin", "*");

        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        string data = request.downloadHandler.text;
        long status = request.responseCode;
        //Debug.Log(status);

        if (status / 100 != 2) {
            SoundManager.PlaySound(SoundType.ERROR);
            Debug.Log("Status: {status} - Error: {data}");
            var error = JsonUtility.FromJson<ErrorResponse>(data);
            GameManager.error = $"Erro: {status} - {error.message}";
            SceneManager.LoadScene("Error");
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
        //request.SetRequestHeader("Access-Control-Allow-Origin", "*");

        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        string data = request.downloadHandler.text;
        long status = request.responseCode;
        //Debug.Log(status);

        if (status / 100 != 2) {
            SoundManager.PlaySound(SoundType.ERROR);
            Debug.Log("Status: {status} - Error: {data}");
            var error = JsonUtility.FromJson<ErrorResponse>(data);
            GameManager.error = $"Erro: {status} - {error.message}";
            SceneManager.LoadScene("Error");
        }

        // This isn't required, but I prefer to pass in a callback so that I can
        // act on the response data outside of this function
        else if (callback != null) {
            callback(data);

        }
    }
}
