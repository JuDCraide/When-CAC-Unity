using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to handle the "How to Play" screen of the game
public class HowToPlay : MonoBehaviour {

    public TMPro.TMP_Text title;
    public TMPro.TMP_Text date;
    public GameObject guessButton;
    bool revealed = false;

    public void onGuessClicked() {
        if (DateInput.value != null) {
            SoundManager.PlaySound(SoundType.GUESS);
            revealed = !revealed;
            if (revealed) {
                title.text = "ESTRAGARAM O CHURRASCO - Ep.1074";
                date.text = "06/10/2017";
                guessButton.SetActive(true);
            }
            else {
                title.text = "ESTRAGARAM O CHURRASCO - Ep.???";
                date.text = "??/??/????";
                guessButton.SetActive(false);
            }
        }
    }
}