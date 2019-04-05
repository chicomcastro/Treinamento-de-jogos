using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    // Public atributes
    // Declare dinamic and static parameters
    public float rocketMass = 0.5f;
    public float propellerMass = 0.5f;
    public float propellerForce = 10.0f;
    public float massFlux = 0.1f;
    
    // Private atributes
    private Rigidbody2D rb;     // Reference to Rigidbody2D component attached to this object
    
    void Start()
    {
        // Get reference to correct component privatly
        rb = GetComponent<Rigidbody2D>();
        
        // Check if it goes without any errors
        if (rb == null)
            Debug.LogWarning("There's no rigidbody attached to " + gameObject.name);
    }

    void FixedUpdate()
    {
        // Used for autolaunch and control
        // rb.velocity = new Vector3(0,10,0);
        // return;
        
        // Interaction with player
        if (Input.GetButton("Vertical"))
        {
            // Add a propulsion forse to rigidbody2D (rb)
            rb.AddForce(new Vector2(0, propellerForce));
            
            // Reduces mass of propellent with use
            if (GetComponent<Rigidbody2D>().mass > rocketMass)
            {
                propellerMass -= (float) massFlux * Time.deltaTime;
            }
            rb.mass = rocketMass + propellerMass;
        }
    }
}
