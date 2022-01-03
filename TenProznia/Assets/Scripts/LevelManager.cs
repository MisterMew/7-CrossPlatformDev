using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private Button[] levelButtons;

    public SceneTransitioner transition;

    public void SelectLevel(int levelIndex) {
        transition.FadeToScene(levelIndex);
    }

    private void Awake() {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1); //Save the level reached in player prefs

        if (PlayerPrefs.GetInt("Level") >= 2) {
            levelReached = PlayerPrefs.GetInt("Level");
        }

        levelButtons = new Button[transform.childCount];
        for (int i = 0; i < levelButtons.Length; i++) {
            levelButtons[i] = transform.GetChild(i).GetComponent<Button>();
            levelButtons[i].GetComponentInChildren<Text>().text = ("0" + (i + 1).ToString());

            if (i + 1 > levelReached) {
                levelButtons[i].interactable = false; //Disable all buttons not yet reached
            }
        }
    }

    public void LoadLevel(int level) {
        PlayerPrefs.SetInt("Level", level);
    }
}