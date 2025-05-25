using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkYoutube : MonoBehaviour {
    public ShowRounds showRounds = null;
    public string fixedId = null;

    public void Open() {
        var round = GameManager.game.round;
        if (showRounds != null) {
            round = showRounds.round;
        }
        var id = GameManager.game.result.rounds[round].id;
        Application.OpenURL($"https://www.youtube.com/watch?v={id}");
    }
    public void OpenFixed() {
        if(fixedId != null) {
            Application.OpenURL($"https://www.youtube.com/watch?v={fixedId}");
        }
    }
}
