using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {
    public void GoToPlay() {
        SceneManager.LoadScene("GameRound");
    }

    public void GoToSeed() {
        SceneManager.LoadScene("Seed");
    }


    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        GameManager.game = null;
        GameManager.seed = null;
    }

    public void GoToHowToPlay() {
        SceneManager.LoadScene("HowToPlay");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
