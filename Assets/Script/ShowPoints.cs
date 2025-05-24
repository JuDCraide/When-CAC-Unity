using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPoints : MonoBehaviour {
    public TMPro.TMP_Text points;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.game != null) {
            //Debug.Log("ShowPoints: " + GameManager.game.result.totalPoints);
            points.text = GameManager.game.result.totalPoints.ToString();
        }
    }
}
