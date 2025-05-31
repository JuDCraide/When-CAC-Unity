using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the seed input set by the user
public class SetSeed : MonoBehaviour {
    public TMPro.TMP_InputField seedInput;
    public void UpdateSeed() {
        //Debug.Log(seedInput.text);
        SoundManager.PlaySound(SoundType.TYPED);
        GameManager.seed = seedInput.text;
    }
}
