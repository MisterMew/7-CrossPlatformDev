using UnityEngine;
using TMPro;

public class StatisticManager : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    private int flowerOrbs = 0;

     /// START
    /* Set the starting values */
    private void Start() {
        flowerOrbs = 0;
    }

     /// UPDATE
    /* Update the GUI text to match the collectible count */
    private void Update() {
        scoreText.text = flowerOrbs.ToString("0");
    }

     /// ON TRIGGER
    /* When colliding with a collectible */
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Orb") { //If the collided object is an Orb
            flowerOrbs++;                   //Add the collectible to the total
            Destroy(other.gameObject, 0F); //Destroy the collected gameObject
        }
    }
}
