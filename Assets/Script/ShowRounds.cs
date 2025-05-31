using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script shows the rounds in the game and if clickable, allows the user to select a round by clicking on it
public class ShowRounds : MonoBehaviour {
    public int round = 1;
    public ShowRound[] rounds;
    public ShowRound currentRound = null;
    public bool clickable = false;

    // Start is called before the first frame update
    void Start() {
        currentRound = rounds[0];
        SetRound(round);
    }

    // Update is called once per frame
    void Update() {
        if (!clickable && GameManager.game != null && GameManager.game.round != round) {
            round = GameManager.game.round;
            SetRound(round);
        }
        if (round == 1) {
            SetRound(round);
        }
    }

    public void SetRound(int newRound) {
        this.round = newRound;
        currentRound.setSelected(false);
        currentRound = rounds[round - 1];
        currentRound.setSelected(true);
    }

    public void SetRoundByClick(ShowRound showRound) {
        //Debug.Log("SetRound: " + showRound.number);
        if (clickable && showRound.number != round) {
            SoundManager.PlaySound(SoundType.BUTTON);
            this.round = showRound.number;
            currentRound.setSelected(false);
            currentRound = rounds[round - 1];
            currentRound.setSelected(true);
        }
    }
}
