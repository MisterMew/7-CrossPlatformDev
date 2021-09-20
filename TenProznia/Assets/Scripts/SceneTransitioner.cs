using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour {
    /// Variables
    public AudioMixer audioMixer = default;
    public Animator crossfade = default;
    public float transitionTime = 1f;
    private int sceneToLoad = 0;

    public void Awake() {
        StartCoroutine(AudioMixerSliders.StartFade(audioMixer, "volMaster", 1F, 1f));
    }

    public void FadeToScene(int sceneIndex) {
        sceneToLoad = sceneIndex;
        crossfade.SetTrigger("FadeOut");
        StartCoroutine(AudioMixerSliders.StartFade(audioMixer, "volMaster", 3F, 0.0001f));
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
