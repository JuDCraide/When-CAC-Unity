using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to link to the game round YouTube video 
public class LinkYoutube : MonoBehaviour {
    public ShowRounds showRounds = null;
    public string fixedId = null;

    public void Open() {
        SoundManager.PlaySound(SoundType.LINK);
        var round = GameManager.game.round;
        if (showRounds != null) {
            round = showRounds.round;
        }
        var id = GameManager.game.result.rounds[round].id;
        Application.OpenURL($"https://www.youtube.com/watch?v={id}");
    }

    public void OpenFixed() {
        SoundManager.PlaySound(SoundType.LINK);
        if (fixedId != null) {
            Application.OpenURL($"https://www.youtube.com/watch?v={fixedId}");
        }
    }
}
