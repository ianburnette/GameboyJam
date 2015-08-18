using UnityEngine;
using System.Collections;

public class doorScript : MonoBehaviour {

	public GameObject uiBody, uiKey;
	public Collider2D collider;
	public Rigidbody2D rb;
	public bool haveKey;

	void OnTriggerEnter2D (Collider2D col){
		if (col.transform.tag == "Player") {
			if (haveKey)
				Open ();
			else
				ShowUI(0);
		} else if (col.transform.tag == "Head") {
			ShowUI(1);
		}
	}

	void OnTriggerExit2D (Collider2D col){
		if (col.transform.tag == "Head" || col.transform.tag == "Player") {
			HideUI();
		}
	}

	void ShowUI(int whichHit){
		if (whichHit == 0) {
			uiKey.SetActive(true);
		}else {
			if (!haveKey) {
				uiKey.SetActive(true);
			} else {
				uiBody.SetActive(true);
			}
		}
		
	}

	void HideUI(){
		uiBody.SetActive (false);
		uiKey.SetActive(false);
	}

	void Open(){
		collider.enabled = false;
		rb.isKinematic = false;
		GameObject.Find ("Player").SendMessage ("UseKey");
	}
}
