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
        //Debug.Log("DateInput: " + dateText.text);
        //Debug.Log("Value: " + value);
    }

    public void UpdateDate() {
        //Debug.Log(dateText.text);
        if(dateText.text.Contains("/")) {
            return;
        }
        value = dateText.text;
        dateText.text = FomatDateUtil.stringDateToSlash(value);
    }
}
