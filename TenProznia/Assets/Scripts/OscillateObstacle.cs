using UnityEngine;

public class OscillateObstacle : MonoBehaviour {
    public int rotationSpeed = 0;
    private void Update() {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); //rotates 50 degrees per second around z axis
    }
}
