using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to display the total points in the game
public enum TotalPointsType {
    EP,
    DATE,
    TOTAL
}

public class ShowPoints : MonoBehaviour {
    public TMPro.TMP_Text points;
    public TotalPointsType typePoints = TotalPointsType.TOTAL;

    void Awake() {
        points.text = "";
    }


    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.game != null) {
            //Debug.Log("ShowPoints: " + GameManager.game.result.totalPoints);
            switch (typePoints) {
                case TotalPointsType.EP:
                    points.text = GameManager.game.result.epTotal.ToString();
                    break;
                case TotalPointsType.DATE:
                    points.text = GameManager.game.result.dateTotal.ToString();
                    break;
                case TotalPointsType.TOTAL:
                    points.text = GameManager.game.result.totalPoints.ToString();
                    break;
            }
        }
    }
}
