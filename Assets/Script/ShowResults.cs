using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowResults : MonoBehaviour {
    public TMPro.TMP_Text epGuess;
    public TMPro.TMP_Text epRes;
    public TMPro.TMP_Text epDiff;
    public TMPro.TMP_Text epPoints;
    public TMPro.TMP_Text dateGuess;
    public TMPro.TMP_Text dateRes;
    public TMPro.TMP_Text dateDiff;
    public TMPro.TMP_Text datePoints;
    public TMPro.TMP_Text roundPoints;
    public TMPro.TMP_Text title;
    public TMPro.TMP_Text date;
    public ShowRounds showRounds = null;


    void Awake() {
        epGuess.text = "";
        epRes.text = "";
        epDiff.text = "";
        epPoints.text = "";
        dateGuess.text = "";
        dateRes.text = "";
        dateDiff.text = "";
        datePoints.text = "";
        roundPoints.text = "";
        title.text = "";
        date.text = "";
    }


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        var round = GameManager.game.round;
        if (showRounds != null) {
            round = showRounds.round;
        }
        //Debug.Log(GameManager.game.round);
        if (GameManager.game != null && GameManager.game.result.rounds.ContainsKey(round)) {
            epGuess.text = GameManager.game.result.rounds[round].ep.guess.ToString();
            epRes.text = GameManager.game.result.rounds[round].ep.res.ToString();
            epDiff.text = GameManager.game.result.rounds[round].ep.diff.ToString();
            epPoints.text = GameManager.game.result.rounds[round].ep.points.ToString();
            dateGuess.text = GameManager.game.result.rounds[round].date.guess.ToString();
            dateRes.text = GameManager.game.result.rounds[round].date.res.ToString();
            dateDiff.text = GameManager.game.result.rounds[round].date.diff.ToString();
            datePoints.text = GameManager.game.result.rounds[round].date.points.ToString();
            roundPoints.text = GameManager.game.result.rounds[round].roundTotal.ToString();
            date.text = GameManager.game.result.rounds[round].date.res.ToString();
            title.text = GameManager.game.result.rounds[round].title;
        }
    }
}
