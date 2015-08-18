using UnityEngine;
using System.Collections;

public class spikesScript : MonoBehaviour {

	public GameObject particles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		//print ("entered");
		if (col.transform.tag == "Head") {
			Instantiate(particles, transform.position, Quaternion.identity);
			col.GetComponent<health>().RestartCheckpoint();
		}
	}
}
