using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    /// Variables
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverlay;

     /// UPDATE
    /* Check update for key press to pause */
    private void Update() {
        if (ValidatePauseInput()) {
            if (gameIsPaused) { //If the game is paused
                ResumeGame();  //Resume the game.
            } else {
                PauseGame(); //Otherwise the game is unpaused, so pause it
            }
        }
    }

     /// GAME: Resume
    /* Resume the game if paused */
    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        gameOverlay.SetActive(true);
        Time.timeScale = 1F;
        gameIsPaused = false;
    }

     /// GAME: Pause
    /* Pause the game */
    public void PauseGame() {
        pauseMenuUI.SetActive(true);
        gameOverlay.SetActive(false);
        Time.timeScale = 0F;
        gameIsPaused = true;
    }

     /// RETURN MAIN
    /*  */
    public void ReturnToMenu() {
        //SceneManager.LoadScene();
    }

     /// GAME: RESTART
    /* Restarts the current game */
    public void RestartGame() {
        SceneManager.LoadScene("EndlessVoid");
        ResumeGame();
    }

     /// VALIDATE INPUT
    /* Validate if an input to trigger pausing has occured */
    public bool ValidatePauseInput() {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape)) {
            return true;
        }
        return false;
    }
}
