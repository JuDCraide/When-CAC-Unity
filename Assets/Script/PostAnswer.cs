using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostAnswer : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        PostGuessAnswer();
    }

    // Update is called once per frame
    void Update() {

    }

    public void PostGuessAnswer() {
        Debug.Log("PostGuessAnswer");
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
        Debug.Log(res.ep.diff);
        Debug.Log(res.date.diff);
    }


    public void onNextRound() {
        GameManager.game.round++;
        SceneManager.LoadScene("GameRound");
    }
}
