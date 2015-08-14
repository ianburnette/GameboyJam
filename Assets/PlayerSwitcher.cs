using UnityEngine;
using System.Collections;

public class PlayerSwitcher : MonoBehaviour {

	public Transform player, playerHead, smoke;

	public Rigidbody2D playerRB;

	public Animator anim;

	public PlayerControls playerCont;

	public Collider2D myTrigger;

	Vector2 headStartLocation, smokeStartPosition;

	public bool playerInControl;

	public ScreenSwitcher cameraScript;

	public bool inRange;

	// Use this for initialization
	void Start () {
		player = transform;
		headStartLocation = player.position - playerHead.position;
		smokeStartPosition = player.position - smoke.position;
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.transform.tag == "Head" && !playerInControl) {
			inRange = true;
			SwitchController();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Head") {
			SwitchController();
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.transform.tag == "Head") {
			inRange = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2") && playerCont.grounded){
			SwitchController();
		}if (player == null) {
			player = transform;
		}
	}

	void ReEnableTrigger(){
		myTrigger.enabled = true;
	}

	void SwitchController(){
		if (playerInControl) {
			playerCont.enabled = false;
			playerHead.gameObject.SetActive (true);
			playerHead.rotation = Quaternion.identity;
			smoke.parent = playerHead;
			playerInControl = false;
			anim.SetBool("headless", true);
			playerRB.isKinematic = true;
			myTrigger.enabled = false;
			Invoke ("ReEnableTrigger", 2f);
			cameraScript.followHead = true;
		} else if (inRange){
			playerHead.position = (Vector2)player.position - headStartLocation;
			playerHead.gameObject.SetActive(false);
			smoke.parent = player;
			playerCont.enabled = true;
			playerInControl = true;
			anim.SetBool("headless", false);
			playerRB.isKinematic = false;
			smoke.position = (Vector2)player.position - smokeStartPosition;
			smoke.position = new Vector3 (smoke.position.x, smoke.position.y, -1f);
			cameraScript.followHead = false;
		}
	}
}
