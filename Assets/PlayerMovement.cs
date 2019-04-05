using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public atributes
    public float speed;         // Setting speed for our player
    public Animator anim;       // We're gonna use public reference for animator (manually attached from Editor)
    
    void Update()
    {
        // Perform basic inputs to know in which direction player should move
        Vector2 deltaPos;
        deltaPos = new Vector2(0, 0);       // Initially we don't know where to move, só \delta x = (0,0)
        if (Input.GetKey(KeyCode.W))        // Get input data from W key and set respectivelly direction 
        {
            deltaPos += new Vector2(0, 1);
            anim.Play("player_up");
        }
        else if (Input.GetKey(KeyCode.A))   // Get input data from A key and set respectivelly direction 
        {
            deltaPos += new Vector2(-1, 0);
            anim.Play("player_left");
        }
        else if (Input.GetKey(KeyCode.S))   // Get input data from S key and set respectivelly direction 
        {
            deltaPos += new Vector2(0, -1);
            anim.Play("player_down");
        }
        else if (Input.GetKey(KeyCode.D))   // Get input data from D key and set respectivelly direction 
        {
            deltaPos += new Vector2(1, 0);
            anim.Play("player_right");
        }

        // Used for animate our states in animator controller
        if (deltaPos.magnitude == 0)            // If we're not gonna move this frame
            anim.SetBool("haveStoped", true);   // Set one of idle states animation
        else
            anim.SetBool("haveStoped", false);  // Else, we're moving then do not wanna animation transitions

        // This is some examples for access animator parameter data (remember to create them and access with the correct name)
        //anim.SetFloat("vel_y", newPos.y);     // Set is linked to write new values, then we have two arguments
        //anim.GetFloat("vel_x");               // Get is linked to read values from existing atributes

        // For finish, we have to tell our transform for where we're want to move based on speed magnitude and at a
        // fixed amount of time (remember that Time.deltaTime is very important to normalize time between frame calls)
        transform.position += (Vector3)deltaPos.normalized * speed * Time.deltaTime;
    }
}

/* EXERCISES:
1) Try to move using method Input.GetButton(string) instead of Input.GetKey(KeyCode)
2) Try to get values from Input.GetAxis(string) to define deltaPos direction
3) Implement public KeyCodes (as global atributes) to define player controls publically from Editor
4) Use public KeyCodes implemented on exercise 3 to implement a second player (make other animated object with the same script, but
with other KeyCodes to control movement.
*/
