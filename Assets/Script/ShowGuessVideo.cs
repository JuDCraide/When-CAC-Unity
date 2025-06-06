using UnityEngine;
using UnityEngine.UI;

// This script is used to display the guess video in the UI
public class ShowGuessVideo : MonoBehaviour {
    public TMPro.TMP_Text title;
    public Image image;
    string src = "R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==";

    void Awake() {
        title.text = "";
    }

    // Start is called before the first frame update
    void Start() {
        title.text = "";
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.game?.currentGuessVideo != null &&
            (string.IsNullOrEmpty(title.text) ||
            GameManager.game?.currentGuessVideo.formattedTitle != title.text)
         ) {
            title.text = GameManager.game?.currentGuessVideo.formattedTitle;

            //Debug.Log("ShowGuessVideo: " + GameManager.game?.currentGuessVideo.imageUrl);
            //var src = GameManager.game?.currentGuessVideo.imageUrl.Replace("data:image/webp;base64,", "");
            var src = GameManager.game?.currentGuessVideo.imageUrl.Replace("data:image/jpg;base64,", "");
            //Debug.Log("ShowGuessVideo: " + src);
            byte[] b64_bytes = System.Convert.FromBase64String(src);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(b64_bytes);
            // Debug.Log($"Texture dimensions: {tex.width}x{tex.height}, Format: {tex.format}");
            //Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
            image.sprite = sprite;
        }
    }
}
