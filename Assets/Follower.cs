using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for applying when we desire a follow mechanic on Y axis (for now)
public class Follower : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public float tolerance;
    private float t0;
    private float offset;
    private bool haveMoved = false;

    void Update()
    {
        // Wait for initial conditions / setup
        if (Mathf.Abs(transform.position.y - target.position.y) < tolerance && !haveMoved)
        {
            offset = transform.position.y - target.position.y;
            t0 = Time.time;
            return;
        }
        else // Move effectivally following target
        {
            haveMoved = true;
            float t = Time.time - t0;
            float w = 0.01f;
            offset *= Mathf.Pow((2.71f), -w * t) * Mathf.Cos(w * t);
            offset += tolerance * (1 - Mathf.Pow((2.71f), -w * t));
        }

        // Set desiredPosition to pursue, respecting constrains of Z axis (only for 2D games)
        Vector3 desiredPosition = target.position;
        desiredPosition.y += offset;
        desiredPosition.z = transform.position.z;

        transform.position = desiredPosition;
    }
}
