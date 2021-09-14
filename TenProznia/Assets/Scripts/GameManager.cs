using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    /// Variables
    bool gameEnded = false;
    public float restartDelay = 1f;

    private void Awake() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    /// GAME: END
    /* Ends the game */
    public void EndGame() {
        if (gameEnded == false) {
            gameEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
