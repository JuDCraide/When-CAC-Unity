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

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (GameManager.game != null) {
            epGuess.text = GameManager.game.result.rounds[GameManager.game.round].ep.guess.ToString();
            epRes.text = GameManager.game.result.rounds[GameManager.game.round].ep.res.ToString();
            epDiff.text = GameManager.game.result.rounds[GameManager.game.round].ep.diff.ToString();
            epPoints.text = GameManager.game.result.rounds[GameManager.game.round].ep.points.ToString();
            dateGuess.text = GameManager.game.result.rounds[GameManager.game.round].date.guess.ToString();
            dateRes.text = GameManager.game.result.rounds[GameManager.game.round].date.res.ToString();
            dateDiff.text = GameManager.game.result.rounds[GameManager.game.round].date.diff.ToString();
            datePoints.text = GameManager.game.result.rounds[GameManager.game.round].date.points.ToString();
            datePoints.text = GameManager.game.result.rounds[GameManager.game.round].roundTotal.ToString();
        }
    }
}
