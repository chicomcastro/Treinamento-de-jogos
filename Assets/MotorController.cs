using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    public float rocketMass = 0.5f;
    public float propellerMass = 0.5f;
    public float propellerForce = 10.0f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogWarning("There's no rigidbody attached to " + gameObject.name);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // rb.velocity = new Vector3(0,10,0);
        // return;

        if (Input.GetButton("Vertical"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, propellerForce));
            if (GetComponent<Rigidbody2D>().mass > rocketMass)
            {
                propellerMass -= (float)0.1 * Time.deltaTime;
            }
            GetComponent<Rigidbody2D>().mass = rocketMass + propellerMass;
        }
    }
}
