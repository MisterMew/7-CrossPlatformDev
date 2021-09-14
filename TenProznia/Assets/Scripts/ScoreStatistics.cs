using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ScoreStatistics : MonoBehaviour {
    /// Variables
    public Transform player;
    public TextMeshProUGUI distanceText;

     /// START
    /* Set values to zero */
    private void Start() {
        distanceText.text = "0m";
    }

    private void Update() {
        distanceText.text = player.position.z.ToString("0m");
    }
}
