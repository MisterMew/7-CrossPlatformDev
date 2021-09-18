using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    /// Variables
    public AudioSource musicSource;
    public AudioClip[] musicSoundtrack;

    private void Awake() {
        musicSource = GetComponent<AudioSource>();
    }

    private void Start() {
    }
}