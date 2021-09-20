using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    /// Variables
    bool gameEnded = false;
    public float restartDelay = 1F;

     /// GAME: END
    /* Ends the game */
    public void EndGame() {
        if (gameEnded == false) {
            gameEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
