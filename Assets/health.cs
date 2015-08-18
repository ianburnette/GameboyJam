using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {

	public Vector2 checkpointPosition;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			RestartCheckpoint();
		}
	}

	public void RestartCheckpoint(){
		rb.velocity = Vector2.zero;
		transform.position = checkpointPosition;
	}

	public void SavePosition(){
		checkpointPosition = transform.position;
	}
}
