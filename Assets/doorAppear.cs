using UnityEngine;
using System.Collections;

public class doorAppear : MonoBehaviour {
	
	public GameObject sprites;
	public BoxCollider2D doorCol;
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Head") {
			doorCol.enabled = true;
			sprites.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
