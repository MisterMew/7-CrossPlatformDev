using UnityEngine;

public class PlayerShatter : MonoBehaviour {

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float shatterForce = 50f;
    public float shatterRadius = 4f;
    public float shatterUpward = 0.4f;

    public Material matPlayer;

     /// START
    /* Upon start */
    void Start() {
        cubesPivotDistance = cubeSize * cubesInRow / 2;                                         // calculate pivot distance
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);   // use this value to create pivot vector
    }

     /// SHATTER Function
    /* Create the shattering effect */
    public void shatter() {
        gameObject.SetActive(false);    //make object disappear

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++) {
            for (int y = 0; y < cubesInRow; y++) {
                for (int z = 0; z < cubesInRow; z++) {
                    createPiece(x, y, z);
                }
            }
        }

        Vector3 shatterPos = transform.position;                                    //get shatter position
        Collider[] colliders = Physics.OverlapSphere(shatterPos, shatterRadius);    //get colliders in that position and radius
        foreach (Collider hit in colliders) {                                       //add shatter force to all colliders in that overlap sphere
            Rigidbody rb = hit.GetComponent<Rigidbody>();                           //get rigidbody from collider object
            if (rb != null) {
                rb.AddExplosionForce(shatterForce, transform.position, shatterRadius, shatterUpward);   //add shatter force to this body with given parameters
            }
        }

    }


    void createPiece(int x, int y, int z) {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var Renderer = piece.GetComponent<Renderer>();              // Get renderer component
        piece.GetComponent<Renderer>().material = matPlayer;

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }

}
