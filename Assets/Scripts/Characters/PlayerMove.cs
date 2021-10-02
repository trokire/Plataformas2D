using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2f;
    public float jumpForce = 10f;
    public bool isJoystickRight;
    public bool isJoystickLeft;
    public bool isJoystickJump;

    private Rigidbody2D body;
    private Animator anim;
    private float horizontal;
    private int costat;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        costat = 1;
        isJoystickRight = false;
        isJoystickLeft = false;
        isJoystickJump = false;
    }

    public void JoystickJumpPress()
    {
        isJoystickJump = true;
    }

    public void JoysticJumpRelease()
    {
        isJoystickJump = false;
    }

    public void JoystickRightPress()
    {
        isJoystickRight = true;
    }

    public void JoystickLeftPress()
    {
        isJoystickLeft = true;
    }

    public void JoystickRightRelease()
    {
        isJoystickRight = false;
    }

    public void JoystickLeftRelease()
    {
        isJoystickLeft = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right") || isJoystickRight == true)
        {
            costat = 1;
            anim.SetBool("walk", true);
            body.velocity = new Vector2(runSpeed, body.velocity.y);
        } 
        else if (Input.GetKey(KeyCode.A) || Input.GetKey("left") || isJoystickLeft == true)
        {
            costat = -1;            
            anim.SetBool("walk", true);

            body.velocity = new Vector2(-runSpeed, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
            anim.SetBool("walk", false);            
        }

        if (Input.GetKey(KeyCode.Space) && CheckGround.isGrounded || isJoystickJump && CheckGround.isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x,jumpForce);
            anim.SetBool("jump", true);
        }
        transform.localScale = new Vector3(costat, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Grounds")
        {
            anim.SetBool("jump", false);
        }
    }
}
