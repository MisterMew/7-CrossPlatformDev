using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerodynamics : MonoBehaviour {
    /// Variables
    public float resistance; //Resistance factor per k/m^3
    public float radius;    //Bird radius

    private float area;
    private float maxResistance;

    public Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        area = Mathf.PI * Mathf.Pow(radius, 2F);           //Get the constant area
        maxResistance = area * Mathf.Pow(resistance, 3F); //Get the maximum resistance
    }
}
