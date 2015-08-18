using UnityEngine;
using System.Collections;

public class SpikeActivator : MonoBehaviour {

	public GameObject[] spikesToActivate;

	// Use this for initialization
	void Start () {
		foreach (GameObject spike in spikesToActivate) {
			spike.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate(){
		foreach (GameObject spike in spikesToActivate) {
			spike.SetActive(true);
		}
	}
}
