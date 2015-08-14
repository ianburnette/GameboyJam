using UnityEngine;
using System.Collections;

public class ScreenSwitcher : MonoBehaviour {

	public bool followHead;
	bool switching;

	public Transform head, player;

	public PlayerControls playerControls;
	public HeadControls headControls;

	public float screenXdistance, screenYdistance, maxXoffset, maxYoffset;
	public float switchTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (followHead && !switching) {
			if (head.position.y > transform.position.y + maxYoffset)//off to right
				Switch (1);
			if (head.position.x < transform.position.x - maxYoffset)//off to right
				Switch (2);
			if (head.position.x > transform.position.x + maxXoffset)//off to right
				Switch (4);
			if (head.position.x < transform.position.x - maxXoffset)//off to right
				Switch (3);
		} else if (!switching){
			if (player.position.y > transform.position.y + maxYoffset)//off to right
				Switch (1);
			if (player.position.x < transform.position.x - maxYoffset)//off to right
				Switch (2);
			if (player.position.x > transform.position.x + maxXoffset)//off to right
				Switch (4);
			if (player.position.x < transform.position.x - maxXoffset)//off to right
				Switch (3);
		}
	}

	void Switch(int dir){
		switching = true;
		if (followHead) {
			head.GetComponent<Rigidbody2D> ().isKinematic = true;
			headControls.enabled = false;
		} else {
			player.GetComponent<Rigidbody2D> ().isKinematic = true;
			playerControls.enabled = false;
		}
		
		if (dir == 1) {
			iTween.MoveTo (gameObject, iTween.Hash (
				"y", transform.position.y + screenYdistance, 
				"time", switchTime
				));
		}
		if (dir == 2) {
			iTween.MoveTo (gameObject, iTween.Hash (
				"y", transform.position.y - screenYdistance, 
				"time", switchTime
				));
		}
		if (dir == 3) {
			iTween.MoveTo (gameObject, iTween.Hash (
				"x", transform.position.x - screenXdistance, 
				"time", switchTime
				));
		}
		if (dir == 4) {
			iTween.MoveTo (gameObject, iTween.Hash (
			"x", transform.position.x + screenXdistance, 
			"time", switchTime
			));
		}
		Invoke ("DoneSwitching", switchTime);
	}

	void DoneSwitching(){
		switching = false;
		if (followHead) {
			head.GetComponent<Rigidbody2D> ().isKinematic = false;
			headControls.enabled = true;
		} else {
			player.GetComponent<Rigidbody2D> ().isKinematic = false;
			playerControls.enabled = true;
		}
	}
}
