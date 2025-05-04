using TMPro;
using UnityEngine;

public class ShowRound : MonoBehaviour {
    public GameObject round;
    public GameObject selectedRound;
    //public TextMesh roundText;
    //public TextMesh selectedRoundText;
    public int number;

    // Start is called before the first frame update
    void Start() {
        selectedRound.SetActive(false);
        selectedRound.GetComponentInChildren<TextMeshProUGUI>().text = number.ToString();
        round.SetActive(true);
        round.GetComponentInChildren<TextMeshProUGUI>().text = number.ToString();
    }

    public void setSelected(bool selected) {
        selectedRound.SetActive(selected);
        round.SetActive(!selected);
    }

}
