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

        //rigidbody.MovePosition(rigidbody.position + Vector3.right * xThrow);
        rigidbody.AddForce(transform.right * sidewaysForce * xThrow); //Apply force to the right

        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {                       //Right xAxial Movement
        //    rigidbody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //Apply force to the right
        //}
        //
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {                         //Left xAxial Movement
        //    rigidbody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //Apply force to the right
        //}
        //
        //if (transform.position.y < 1.875F) {
        //    if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
        //        rigidbody.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        //    }
        //}

        if (rigidbody.position.y < -15F || rigidbody.position.y > 64F) {
            FindObjectOfType<PlayerShatter>().shatter();
            FindObjectOfType<GameManager>().EndGame();
        }
    }

     /// GET AXIAL INPUT
    /* Get the axial input regardless of input controller */
    void GetAxisInput() {
        xThrow = Input.GetAxis("Horizontal") * Time.deltaTime * sidewaysForce; //Return the horizontal axial input
        yThrow = Input.GetAxis("Vertical") * Time.deltaTime * jumpForce;      //Return the vertical axial input
    }
}
