using UnityEngine;

public class PlayerController : MonoBehaviour {
    /// Physics Variables
    public Rigidbody rigidbody;
    public float forwardForce = 2000F;
    public float forwardClamped = 10F;
    public float sidewaysForce = 50f;
    public float jumpForce = 500f;

    /// Axis Variables
    private float xThrow;
    private float yThrow;

    /// Touch Input Variables
    private float touchWidth;
    private float touchHeight;


     /// AWAKE
    /* Define the touch-input area */
    private void Awake() {
        touchWidth = (float)Screen.width / 2F;
        touchHeight = (float)Screen.height / 2F;
    }

     /// START
    /* Upon Start */
    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
    }

     /// FIXED UPDATE
    /* Update dependant on framerate */
    private void FixedUpdate() {
        rigidbody.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.Impulse); //Apply forward force

        GetAxisInput();
        GetTouchInput();
        
        rigidbody.AddForce(transform.right * sidewaysForce * xThrow, ForceMode.Impulse); //Apply horizontal force
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, forwardClamped); //Clamp to restricted exceeding maxSpeed

        if (IsOutOfBounds()) { //End the game if player is out of bounds
            FindObjectOfType<PlayerShatter>().shatter();
            FindObjectOfType<GameManager>().EndGame();
        }
    }

     /// INPUT: AXIAL
    /* Get the axial input regardless of input controller */
    private void GetAxisInput() {
        xThrow = Input.GetAxis("Horizontal") * Time.deltaTime * sidewaysForce; //Return the horizontal axial input
        yThrow = Input.GetAxis("Vertical") * Time.deltaTime * jumpForce; //Return the horizontal axial input
    }

     /// INPUT: TOUCH
    /* Get the touch screen inputs */
    private void GetTouchInput() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            Debug.Log(Input.touchCount);

            if (touchPosition.x > 0) {
                rigidbody.AddForce(transform.right * sidewaysForce * xThrow, ForceMode.Impulse);
            }
            else if (touchPosition.x < 0) {
                rigidbody.AddForce(-transform.right * sidewaysForce * xThrow, ForceMode.Impulse);
            }
        }
    }

     /// OUT OF BOUNDS
    /* Validate if the player is Out of bounds */
    private bool IsOutOfBounds() {
        if (rigidbody.position.y < -15F || rigidbody.position.y > 64F) { return true; }
        if (rigidbody.position.x < -256F || rigidbody.position.x > 256F) { return true; }
        return false;
    }
}
