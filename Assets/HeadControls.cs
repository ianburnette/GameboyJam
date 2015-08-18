using UnityEngine;
using System.Collections;

public class HeadControls : MonoBehaviour {

	public float gravDirX, gravDirY;
	public float gravForce;

	public Rigidbody2D rb;

	public HeadGravity gravScript;

	public GameObject key;

	public gravityParticles particleScript;

	// Use this for initialization
	void OnEnable () {
		//gravDirY = 1;
	//	gravScript.ToggleParticles (true);
		particleScript.displayParticles = true;
		particleScript.direction = new Vector2 (gravDirX, gravDirY);
	}

	void OnDisable(){
	//	gravScript.ToggleParticles(false);
		particleScript.displayParticles = false;
		particleScript.StopParticles ();
	}

	public void GetKey(){
		key.SetActive (true);
	}

	public void UseKey(){
		key.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		GetInput ();
		particleScript.direction = new Vector2 (gravDirX, gravDirY);
	}

	void FixedUpdate(){
		ApplyMovement ();
	}

	void ApplyMovement(){
		rb.AddForce (new Vector2 (gravDirX * gravForce, gravDirY * gravForce));
	}

	void GetInput(){
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		
		if (h != 0 && v == 0) {
			if (gravDirX!=h){
				gravDirX = h;
				if (h > 0)
					gravScript.SwitchDirection(3);
				else
					gravScript.SwitchDirection(4);
			}
			gravDirY = 0; 
		} else if (h == 0 && v != 0) {
			if (gravDirY != v){
				gravDirY = v;
				if (v > 0) 
					gravScript.SwitchDirection(2);
				else 
					gravScript.SwitchDirection(1);
			}
			gravDirX = 0;
		}
	}
}
