using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {
    public void GoToPlay() {
        SoundManager.PlaySound(SoundType.BUTTON);
        SceneManager.LoadScene("GameRound");
    }

    public void GoToSeed() {
        SoundManager.PlaySound(SoundType.BUTTON);
        SceneManager.LoadScene("Seed");
    }


    public void GoToMenu() {
        SoundManager.PlaySound(SoundType.BUTTON);
        SceneManager.LoadScene("Menu");
        GameManager.game = null;
        GameManager.seed = null;
        GameManager.error = null;
    }

    public void GoToHowToPlay() {
        SoundManager.PlaySound(SoundType.BUTTON);
        SceneManager.LoadScene("HowToPlay");
    }

    public void QuitGame() {
        SoundManager.PlaySound(SoundType.BUTTON);
        Application.Quit();
    }
}
