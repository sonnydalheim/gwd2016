using UnityEngine;
using System.Collections;

public class playerControllerDoug : MonoBehaviour {

	// Movement variables
	public float runSpeed;
	public float walkSpeed;

	Rigidbody myRB;
	Animator myAnim;

	bool facingRight;

	// Jumping variables
	bool grounded = false;
	Collider[] groundCollisions;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;


	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody>();
		myAnim = GetComponent<Animator>();
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {

		if(grounded && Input.GetAxis("Jump") > 0) {
			grounded =  false;
			myAnim.SetBool("Grounded", grounded);
			myRB.AddForce(new Vector3(0, jumpHeight, 0));
		}

		// Drawing the sphere by the characters feet
		groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);

		if(groundCollisions.Length > 0) {
			grounded = true;
		}
		else {
			grounded = false;
		}

		myAnim.SetBool("Grounded", grounded);

		float move = Input.GetAxis("Horizontal");
		myAnim.SetFloat("Speed", Mathf.Abs(move));

		float sneaking = Input.GetAxisRaw("Fire3");
		myAnim.SetFloat("Sneaking", sneaking);

		if(sneaking > 0 && grounded) {
			myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0);
		}
		else {
			myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
		}

		if(move > 0 && !facingRight) {
			Flip();
		}
		else if(move < 0 && facingRight) {
			Flip();
		}
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}
}
