using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collisionInfo) {     //Upon collision with another object (recieves information about the "collisionInfo")
        if (collisionInfo.collider.tag == "Obstacle") { //Checking if collided object has "Obstacle" tag
            movement.enabled = false;                  //Disables player movement
            FindObjectOfType<PlayerShatter>().shatter();
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
