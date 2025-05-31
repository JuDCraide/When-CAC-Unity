using UnityEngine;
using UnityEngine.UI;

// This script is used to display the game results for a specific round
public class ShowResults : MonoBehaviour {
    public TMPro.TMP_Text epGuess;
    public TMPro.TMP_Text epRes;
    public TMPro.TMP_Text epDiff;
    public TMPro.TMP_Text epPoints;
    public TMPro.TMP_Text dateGuess;
    public TMPro.TMP_Text dateRes;
    public TMPro.TMP_Text dateDiff;
    public TMPro.TMP_Text datePoints;
    public TMPro.TMP_Text roundPoints;
    public TMPro.TMP_Text title;
    public TMPro.TMP_Text date;
    public TMPro.TMP_InputField seed = null;
    public Image image;
    public ShowRounds showRounds = null;


    // Start is called before the first frame update
    void Start() {
        epGuess.text = "";
        epRes.text = "";
        epDiff.text = "";
        epPoints.text = "";
        dateGuess.text = "";
        dateRes.text = "";
        dateDiff.text = "";
        datePoints.text = "";
        roundPoints.text = "";
        title.text = "";
        date.text = "";
    }

    // Update is called once per frame
    void Update() {
        var round = GameManager.game.round;
        if (showRounds != null) {
            round = showRounds.round;
        }
        //Debug.Log(GameManager.game.round);
        if (GameManager.game != null && GameManager.game.result.rounds.ContainsKey(round) && string.IsNullOrEmpty(title.text)) {
            epGuess.text = GameManager.game.result.rounds[round].ep.guess.ToString();
            epRes.text = GameManager.game.result.rounds[round].ep.res.ToString();
            epDiff.text = GameManager.game.result.rounds[round].ep.diff.ToString();
            epPoints.text = GameManager.game.result.rounds[round].ep.points.ToString();
            dateGuess.text = FomatDateUtil.stringDateToSlash(GameManager.game.result.rounds[round].date.guess.ToString());
            dateRes.text = FomatDateUtil.stringDateToSlash(GameManager.game.result.rounds[round].date.res.ToString());
            dateDiff.text = GameManager.game.result.rounds[round].date.diff.ToString();
            datePoints.text = GameManager.game.result.rounds[round].date.points.ToString();
            roundPoints.text = GameManager.game.result.rounds[round].roundTotal.ToString();
            date.text = FomatDateUtil.stringDateToSlash(GameManager.game.result.rounds[round].date.res.ToString());
            title.text = GameManager.game.result.rounds[round].title;

            //Debug.Log("ShowGuessVideo: " + GameManager.game?.currentGuessVideo.imageUrl);
            //var src = GameManager.game?.currentGuessVideo.imageUrl.Replace("data:image/webp;base64,", "");
            var src = GameManager.game.result.rounds[round].image.Replace("data:image/jpg;base64,", "");
            //Debug.Log("ShowGuessVideo: " + src);
            byte[] b64_bytes = System.Convert.FromBase64String(src);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(b64_bytes);
            // Debug.Log($"Texture dimensions: {tex.width}x{tex.height}, Format: {tex.format}");

            //Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
            image.sprite = sprite;

            if (seed != null) {
                seed.text = GameManager.game.seed.ToString();
            }
        }
    }
}
