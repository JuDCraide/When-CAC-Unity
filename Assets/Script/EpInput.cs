using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class EpInput : MonoBehaviour {
    public int latestEp = 1700;
    public Slider epSlider;
    public TMPro.TMP_InputField epText;
    static public int currentValue = 1;

    // Start is called before the first frame update
    void Start() {
        epSlider.maxValue = latestEp;
        UpdateValue(currentValue);
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.game != null && latestEp != GameManager.game.latestEp) {
            //Debug.Log(latestEp);
            latestEp = GameManager.game.latestEp;
            epSlider.maxValue = latestEp;
        }
    }

    public void UpdateValue(int value) {
        if (value > latestEp) {
            value = latestEp;
        }
        else if (value < 1) {
            value = 1;
        }
        currentValue = value;
        epText.text = value.ToString();
        epSlider.value = value;
    }

    public void UpdateValueSlider() {
        int value = (int)epSlider.value;
        if(value != currentValue) {
            SoundManager.PlaySound(SoundType.SLIDER);
            UpdateValue(value);
        }
    }

    public void IncreaseValue() {
        SoundManager.PlaySound(SoundType.INPUT);
        UpdateValue(currentValue + 1);
    }

    public void DecreaseValue() {
        SoundManager.PlaySound(SoundType.INPUT);
        UpdateValue(currentValue - 1);
    }

    public void UpdateValueTextInput() {
        int value = 1;
        string text = new string(epText.text.Where(char.IsNumber).ToArray());
        if (text != currentValue.ToString()) {
            SoundManager.PlaySound(SoundType.TYPED);
        }
        if (text.Length > 0) {
            value = int.Parse(text);
            UpdateValue(value);
        }
    }
    public void PlayInput() {
        SoundManager.PlaySound(SoundType.INPUT);
    }
}
