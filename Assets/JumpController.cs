using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour {

	public float groundDist;
	public bool grounded;
	public LayerMask groundMask;

	public float jumpUpForce, jumpRightForce;
	public float jumpMultiplier;

	public float yLimit, gravForce;

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//CheckGrounded ();
		CheckForRelease();
		if (grounded) {
			CheckForJump();
		}if (!grounded) {

			AdditionalGravity ();
		}

	}

	void OnTriggerStay2D(Collider2D col){
		if (col.transform.tag == "Ground") {
			grounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.transform.tag == "Ground") {
			grounded = false;
		}
	}

	void AdditionalGravity(){
		rb.AddForce (Vector2.down * gravForce);
	}

	void CheckForJump(){
		if (Input.GetButtonDown ("JumpLeft")) {
			Jump(-1);
		}
		if (Input.GetButtonDown ("JumpRight")) {
			Jump(1);
		}
	}

	void CheckForRelease(){
		if (Input.GetButtonUp ("JumpLeft") && rb.velocity.y > 0) {
			print ("released");
			rb.velocity = new Vector2(rb.velocity.x, yLimit);
		}
		if (Input.GetButtonUp ("JumpRight") && rb.velocity.y > 0) {
			print ("released");
			rb.velocity = new Vector2(rb.velocity.x, yLimit);
		}
	}

	void Jump(int dir){
		rb.velocity = new Vector2(jumpRightForce * jumpMultiplier * dir, jumpUpForce * jumpMultiplier);
		//rb.AddForce(new Vector2(jumpRightForce * jumpMultiplier * dir, jumpUpForce * jumpMultiplier));
	}

	void CheckGrounded(){
		if (Physics2D.Raycast (transform.position, Vector2.down, groundDist, groundMask)) {
			grounded = true;
		} else {
			grounded = false;
		}
	}
}
