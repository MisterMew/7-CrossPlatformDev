using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ScoreStatistics : MonoBehaviour {
    public Transform player;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI scoreText;

    void Update() {
        distanceText.text = player.position.z.ToString("0m");
    }
}
