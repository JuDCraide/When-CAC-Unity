using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour {
    public TMPro.TMP_Text error;

    // Start is called before the first frame update
    void Start() {
        error.text = "";
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.error != null) {
            error.text = GameManager.error;
        }
    }
}
