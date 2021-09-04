using UnityEngine;

public class PlayerController : MonoBehaviour {
    /// Physics Variables
    public Rigidbody rigidbody;
    public float forwardForce = 2000F;
    public float sidewaysForce = 50f;
    public float jumpForce = 500f;

    /// Axis Variables
    float xThrow;
    float yThrow;

    /// Grounding Variables
    bool isGrounded = false;
    float distToGround = 1F;


     /// UPDATE
    /* Update once every frame */
    private void Update() {
        GetAxisInput();
    }

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

     /// GET AXIAL INPUT
    /* Get the axial input regardless of input controller */
    void GetAxisInput() {
        xThrow = Input.GetAxis("Horizontal"); //Return the horizontal axial input
        yThrow = Input.GetAxis("Vertical");  //Return the vertical axial input
    }

     /// GROUND CHECK
    /* Check if the player is touching the ground */
    void GroundCheck() {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1F)) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }
}
