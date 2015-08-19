using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	
	public float groundDist;
	public bool grounded;
	public LayerMask groundMask;
	
	public float jumpUpForce, jumpRightForce;
	public float jumpMultiplier;
	
	public float yLimit, gravForce;

	public float hSpeed, speedLimit;
	
	public Rigidbody2D rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//CheckGrounded ();
		CheckForRelease();
		CheckForMovement ();
		if (grounded) {
			CheckForJump();
		}if (!grounded) {
			
			AdditionalGravity ();
		}
		if (Input.GetKeyDown (KeyCode.F1)) {
			Application.LoadLevel(0);
		}
	//	LimitSpeed ();
	}

	void LimitSpeed(){
		if (rb.velocity.magnitude > speedLimit) {
			Vector2 velNorm = rb.velocity.normalized;
			velNorm *= speedLimit;
			rb.velocity = velNorm;
		}
	}
	
	void CheckForMovement(){
		float h = Input.GetAxis ("Horizontal");
		//float v = Input.GetAxis ("Vertical");
		rb.velocity = new Vector2 (h * hSpeed, rb.velocity.y);
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
//		print ("checking Jump");
		if (Input.GetButtonDown ("Jump") && grounded) {
//			print ("released");
			rb.velocity = new Vector2(rb.velocity.x, jumpUpForce * jumpMultiplier);
		}
	}
	
	void CheckForRelease(){
		if (Input.GetButtonUp ("Jump") && rb.velocity.y > 0) {
//			print ("released");
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
