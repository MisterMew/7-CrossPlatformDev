using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerSliders : MonoBehaviour {
    /// Variables
    private static AudioMixerSliders musicTransitionInstance;

    /// Slider Variables
    [SerializeField] string volumeParameter = "volMaster";
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider slider;
    [SerializeField] float volumeMultiplier = 20F;

    /// AWAKE
    /* Execute upon awaking */
    private void Awake() {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    /// START
    /* Execute upon starting */
    void Start() {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }

    private void OnDisable() {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    private void HandleSliderValueChanged(float sliderValue) {
        audioMixer.SetFloat(volumeParameter, Mathf.Log10(sliderValue) * volumeMultiplier);
    }
}
