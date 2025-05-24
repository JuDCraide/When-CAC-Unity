using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRounds : MonoBehaviour {
    public int round = 1;
    public ShowRound[] rounds;
    ShowRound currentRound = null;
    public bool clicable = true;

    // Start is called before the first frame update
    void Start() {
        currentRound = rounds[round - 1];
        currentRound.setSelected(true);
    }

    // Update is called once per frame
    void Update() {
        if (!clicable && GameManager.game != null && GameManager.game.round != round) {
            round = GameManager.game.round;
            SetRound(round);
        }
    }

    public void SetRound(int newRound) {
        if (newRound != currentRound.number) {
            this.round = newRound;
            currentRound.setSelected(false);
            currentRound = rounds[round - 1];
            currentRound.setSelected(true);
        }
    }

    public void SetRoundByClick(ShowRound showRound) {
        //Debug.Log("SetRound: " + showRound.number);
        if (clicable && showRound.number != round) {
            this.round = showRound.number;
            currentRound.setSelected(false);
            currentRound = rounds[round - 1];
            currentRound.setSelected(true);
        }
    }
}
