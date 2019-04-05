using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos;
        newPos = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            newPos += new Vector2(0, 1);
            anim.Play("player_up");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            newPos += new Vector2(-1, 0);
            anim.Play("player_left");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newPos += new Vector2(0, -1);
            anim.Play("player_down");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newPos += new Vector2(1, 0);
            anim.Play("player_right");
        }

        if (newPos.magnitude == 0)
            anim.SetBool("haveStoped", true);
        else
            anim.SetBool("haveStoped", false);

        //anim.SetFloat("vel_y", newPos.y);
        //anim.GetFloat("vel_x");

        transform.position += (Vector3)newPos.normalized * speed * Time.deltaTime;
    }
}
