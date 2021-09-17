using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
     /// AWAKE
    /* Set Screen Orientation */
    private void Awake() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void PlayEndless() {
        SceneManager.LoadScene("EndlessVoid");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
