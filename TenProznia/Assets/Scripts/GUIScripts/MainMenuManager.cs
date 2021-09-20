using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MainMenuManager : MonoBehaviour {
    /// Variables
    private bool cmVirtualCam01 = true;
    private Animator cmAnimator = default;
    [SerializeField] private CinemachineVirtualCamera vCam01 = default;  //Menu camera
    [SerializeField] private CinemachineVirtualCamera vCam02 = default; //Credits camera
    
     /// AWAKE
    /* Get Components */
    private void Awake() {
        Screen.orientation = ScreenOrientation.LandscapeLeft; //Set the screen orientation
        cmAnimator = GetComponent<Animator>();               //Get cinemachine component
    }

     /// UI: Credits
    /* Upon button click, view credits */
    public void ViewCredits() {
        SwitchCMPriority();
    }

     /// UI: Quit
    /* Upon button click, quit the game */
    public void QuitGame() {
        Application.Quit();
    }

    public void ReturnMain() {
        SwitchCMPriority();
    }

     /// CM: Switch Priority
    /* Switch the camera priority */
    private void SwitchCMPriority() {
        if (cmVirtualCam01) {
            vCam01.Priority = 0;  //Switch priority from MAIN camera
            vCam02.Priority = 1; //to CREDITS Camera
        }
        else {
            vCam01.Priority = 1;
            vCam02.Priority = 0;
        }
        cmVirtualCam01 = !cmVirtualCam01;
    }
}
