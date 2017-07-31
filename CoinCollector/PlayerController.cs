using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float runSpeed;

	Rigidbody myRB;
	bool facingRight;

	//For Landing
	public bool grounded = false;
	Collider[] groundCollisions;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;
	public AudioClip jumpSound;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody>();
		facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ( grounded && Input.GetMouseButtonDown(0)) {
			grounded = false;
			myRB.AddForce( new Vector3( 0, jumpHeight, 0 ));
			AudioSource.PlayClipAtPoint(jumpSound, transform.position, .3f);
		}
		
		groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
		
		if ( groundCollisions.Length > 0 )
			grounded = true;
		else
			grounded = false;

		float move = Input.GetAxis("Horizontal");
		myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);

		if ( move > 0 && !facingRight ) Flip();
		else if ( move < 0 && facingRight ) Flip();
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.z *= -1;
		transform.localScale = theScale;
	}
	
	public float GetFacing () {
		if ( facingRight ) return 1;
		else return -1;
	}
}
