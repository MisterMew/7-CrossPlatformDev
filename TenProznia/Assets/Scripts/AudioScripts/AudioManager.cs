using UnityEngine;

public class AudioManager : MonoBehaviour {
    /// Variables
    public AudioSource musicSource;

    private void Awake() {
        musicSource = GetComponent<AudioSource>();
    }
}