using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSeed : MonoBehaviour {
    public TMPro.TMP_InputField seedInput;
    public void UpdateSeed() {
        //Debug.Log(seedInput.text);
        GameManager.seed = seedInput.text;
    }
}
