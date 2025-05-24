using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateInput : MonoBehaviour {

    static public string value = "";
    public TMPro.TMP_InputField dateText;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateDate() {
        //Debug.Log(dateText.text);
        value = dateText.text;
    }
}
