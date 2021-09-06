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


     /// START
    /* Upon Start */
    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

     /// FIXED UPDATE
    /* Update dependant on framerate */
    private void FixedUpdate() {
        rigidbody.AddForce(0, 0, forwardForce * Time.deltaTime);

        GetAxisInput();
        rigidbody.AddForce(transform.right * sidewaysForce * xThrow); //Apply horizontal force

        if (IsOutOfBounds()) { //End the game if player is out of bounds
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

     /// OUT OF BOUNDS
    /* Validate if the player is Out of bounds */
    bool IsOutOfBounds() {
        if (rigidbody.position.y < -15F || rigidbody.position.y > 64F) { return true; }
        if (rigidbody.position.x < -256F || rigidbody.position.x > 256F) { return true; }
        return false;
    }
}
