using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
    public Transform player;
    public Vector3 offset;

     /// UPDATE
    /* Update camera to follow the player */
    void Update() {
        transform.position = player.position + offset; //Set camera target position to the player position (with offset)
    }
}
