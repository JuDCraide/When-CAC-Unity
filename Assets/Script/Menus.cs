using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {
    public void GoToPlay() {
        SceneManager.LoadScene("GameRound");
    }

    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
        GameManager.game = null;
    }

    public void GoToHowToPlay() {
        SceneManager.LoadScene("HowToPlay");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
