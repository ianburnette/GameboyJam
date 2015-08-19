using UnityEngine;
using System.Collections;

public class finalDoor : MonoBehaviour {

	public Transform whereToGo, head;

	public GameObject sprites, endUI;
	public BoxCollider2D doorCol;

	public bool ended;

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Head") {
			doorCol.enabled = true;
			sprites.SetActive(true);
			endUI.SetActive (true);
			ended = true;
		}
	}

	// Use this for initialization
	void Start () {
	
	}

	public void GoToRoom(){
		head.position = whereToGo.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (ended) {
			if (Input.GetButtonDown("Fire2")){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
