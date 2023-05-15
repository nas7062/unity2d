using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField]  float speed = 2.0f;
    [SerializeField] float runSpeed = 5f;
    Vector2 motionVector;
   public  Vector2 lastMotionVector;
    Animator animator;
    public bool moving;
    bool running;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

	// Update is called once per frame
	private void Update()
	{
        if(Input.GetKeyDown(KeyCode.LeftShift))
		{
            running = true;
		}
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

       // motionVector.x = horizontal;
        //motionVector.y = vertical;

        motionVector = new Vector2(horizontal, vertical);
        animator.SetFloat("horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("vertical", Input.GetAxisRaw("Vertical"));

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);
        if (horizontal !=0 || vertical !=0)
		{
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);

		}
	}
	void FixedUpdate()
    {
        Move();   
    }
    private void Move()
	{
        rigidbody2d.velocity = motionVector * (running ==true ? runSpeed : speed);
	}
	private void OnDisable()
	{
        rigidbody2d.velocity = Vector2.zero;
	}
}
