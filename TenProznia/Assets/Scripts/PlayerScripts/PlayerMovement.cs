using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody rigidbody;
    public float forwardForce = 2000F;
    public float sidewaysForce = 50f;
    public float jumpForce = 500f;

    float distToGround = 1F;

     /// UPDATE
    /* Update once every frame */
    private void Update() {}

     /// FIXED UPDATE
    /* Update dependant on framerate */
    private void FixedUpdate() {
        rigidbody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            rigidbody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            rigidbody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (isGrounded && Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
            rigidbody.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        GroundCheck();

        if (rigidbody.position.y < -15f) {
            FindObjectOfType<PlayerShatter>().shatter();
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public bool isGrounded = false;
    void GroundCheck() {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1F)) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }
}
