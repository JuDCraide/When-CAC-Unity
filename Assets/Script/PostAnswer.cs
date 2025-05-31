using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is used to make web requests to send the user's guess answer for a game round
// Based on https://discussions.unity.com/t/how-do-i-get-into-the-data-returned-from-a-unitywebrequest/218510/2
// And https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
public class PostAnswer : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        PostGuessAnswer();
    }

    // Update is called once per frame
    void Update() {

    }

    public void PostGuessAnswer() {
        //Debug.Log("PostGuessAnswer");
        string targetUrl = Request.DEFAULT_URL + "/response";
        string postBody = JsonUtility.ToJson(new VideoResponseReq(GameManager.game.uuid, GameManager.game.round, EpInput.currentValue, DateInput.value));
        this.StartCoroutine(Request.PostRequestRoutine(targetUrl, postBody, this.PostGuessAnswerCallback));
    }

    // Callback to act on our response data
    private void PostGuessAnswerCallback(string data) {
        //Debug.Log(data);
        ResultResponse result = JsonUtility.FromJson<ResultResponse>(data);
        //Debug.Log(result.responseVideo.video_id);
        GameManager.game.saveResult(result);

        GameManager.game.result.rounds.TryGetValue(GameManager.game.round, out RoundResult res);
        //Debug.Log(res.title);
        //Debug.Log(res.ep.diff);
        //Debug.Log(res.date.diff);
        EpInput.currentValue = 1;
        DateInput.value = "";
    }


    public void onNextRound() {
        if (GameManager.game == null || !GameManager.game.result.rounds.ContainsKey(GameManager.game.round)) {             // Error
            SoundManager.PlaySound(SoundType.ERROR);
            Debug.Log("Please wait for the current round answer to load first");
            return;
        }
        SoundManager.PlaySound(SoundType.BUTTON);
        if (GameManager.game.round >= 5) {
            GameManager.game.round = 5;
            SceneManager.LoadScene("FullGameResult");
        }
        else {
            GameManager.game.round++;
            SceneManager.LoadScene("GameRound");
        }
    }
}
