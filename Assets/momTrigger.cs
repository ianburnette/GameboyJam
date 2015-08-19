using UnityEngine;
using System.Collections;

public class momTrigger : MonoBehaviour {

	public GameObject mom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Head") {
			mom.SetActive(true);
		}
	}
}
