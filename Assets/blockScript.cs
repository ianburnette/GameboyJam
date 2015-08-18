using UnityEngine;
using System.Collections;

public class blockScript : MonoBehaviour {

	public bool vertical;
	public Rigidbody2D rb;
	public float gravDirX, gravDirY;
	public float gravForce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		if (!vertical) {
			if (h != 0 && v == 0) {
				if (gravDirX != h) {
					gravDirX = h;
//				if (h > 0)
//					gravScript.SwitchDirection(3);
//				else
//					gravScript.SwitchDirection(4);
				}
				gravDirY = 0; 
			}
		}else if (vertical){
			if (h == 0 && v != 0) {
				if (gravDirY != v){
					gravDirY = v;
	//				if (v > 0) 
	//					gravScript.SwitchDirection(2);
	//				else 
	//					gravScript.SwitchDirection(1);
				}
				gravDirX = 0;
			}
		}
		rb.AddForce (new Vector2 (gravDirX * gravForce, gravDirY * gravForce));
	}
}
