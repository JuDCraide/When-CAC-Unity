using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour {

    public TMPro.TMP_Text title;
    public TMPro.TMP_Text date;
    bool revealed = false;

    public void onGuessClicked() {
        revealed = !revealed;
        if (revealed) {
            title.text = "ESTRAGARAM O CHURRASCO - Ep.1074";
            date.text = "06/10/2017";
        }
        else {
            title.text = "ESTRAGARAM O CHURRASCO - Ep.???";
            date.text = "??/??/????";
        }
    }
}