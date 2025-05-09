using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

// Based on https://discussions.unity.com/t/how-do-i-get-into-the-data-returned-from-a-unitywebrequest/218510/2
// And https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity

[Serializable]
public class GameRes {
    public string uuid;
    public int latestEp;
    public string seed;

    public bool checkValid() {
        return !String.IsNullOrEmpty(uuid) && latestEp > 0 && !String.IsNullOrEmpty(seed);
    }
}

public class GetGame : MonoBehaviour {

    public void Start() {
        if (GameManager.game == null) {
            this.StartGame();
        }
        else {
            GetRound();
        }
    }

    public void StartGame() {
        Debug.Log("StartGame");
        string targetUrl = Request.DEFAULT_URL;
        if (!String.IsNullOrEmpty(GameManager.seed)) {
            targetUrl += $"?seed={GameManager.seed}";
        }
        this.StartCoroutine(Request.GetRequestRoutine(targetUrl, this.StartGameResponseCallback));
    }

    // Callback to act on our response data
    private void StartGameResponseCallback(string data) {
        Debug.Log(data);
        GameRes g = JsonUtility.FromJson<GameRes>(data);
        if (!g.checkValid()) {
            // Error
        }
        Debug.Log(g.uuid);
        GameManager.game = new Game(g);
        GetRound();
    }

    public void GetRound() {
        Debug.Log("GetRound");
        string targetUrl = Request.DEFAULT_URL;
        targetUrl += $"/guess?uuid={GameManager.game.uuid}&round={GameManager.game.round}";

        this.StartCoroutine(Request.GetRequestRoutine(targetUrl, GetRoundResponseCallback));
    }

    // Callback to act on our response data
    private void GetRoundResponseCallback(string data) {
        Debug.Log(data);
        GuessVideoRes video = JsonUtility.FromJson<GuessVideoRes>(data);
        GameManager.game.currentGuessVideo = new GuessVideo(video);
        Debug.Log(GameManager.game.currentGuessVideo.formattedTitle);
        Debug.Log(GameManager.game.latestEp);
    }

    public void onAnswer() {
        if(DateInput.value == "") {
            // Error
            Debug.Log("Please input date");
            return;
        }
        SceneManager.LoadScene("GameRoundResult");
    }
}