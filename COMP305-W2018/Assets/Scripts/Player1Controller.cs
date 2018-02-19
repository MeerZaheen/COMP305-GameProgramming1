using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public Transform groundCheck;
    public bool isGround;
    public float groundRadius;
    public LayerMask whatGround;

    private Rigidbody2D rBody;
    private Animator anim;
    private SpriteRenderer sRend;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sRend = this.GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {

        isGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatGround);

        if (Input.GetKey(left))
        {
            rBody.velocity = new Vector2(-moveSpeed, rBody.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rBody.velocity = new Vector2(moveSpeed, rBody.velocity.y);
        } else
        {
            rBody.velocity = new Vector2(0, rBody.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGround)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
        }

        if (rBody.velocity.x < 0)
        {
            sRend.flipX = true;
        }
        else if (rBody.velocity.x > 0)
        {
            sRend.flipX = false;
        }

        anim.SetFloat("Speed", Mathf.Abs(rBody.velocity.x));
        anim.SetBool("Grounded", isGround);
		
	}
}
