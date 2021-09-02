using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
    public Transform player;
    public Vector3 offset;

     /// UPDATE
    /* Update camera to follow player position */
    void Update() {
        transform.position = player.position + offset;
    }
}
