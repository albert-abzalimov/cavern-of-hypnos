using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;
    public LayerMask whereGround;
    public Transform groundpt;
    private bool isGrounded;
    public Animator Anim;
    public SpriteRenderer theSR;
    private bool movingBackwards;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);

        RaycastHit hit;
        if(Physics.Raycast(groundpt.position, Vector3.down, out hit, .3f, whereGround))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f,jumpForce,0f);
        }
        Anim.SetBool("Grounded", isGrounded);
        Anim.SetFloat("moveSpeed", theRB.velocity.magnitude);

        if(!theSR.flipX && moveInput.x < 0)
        {
            theSR.flipX = true;
        } else if(theSR.flipX && moveInput.x > 0)
        {
            theSR.flipX = false;
        }

        if (!movingBackwards && moveInput.y > 0)
        {
            movingBackwards = true;
        }
        else if (movingBackwards && moveInput.y < 0)
        {
            movingBackwards = false;
        }
        Anim.SetBool("movingBackwards", movingBackwards);
    }
}
