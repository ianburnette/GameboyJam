using UnityEngine;
using System.Collections;

public class gravityParticles : MonoBehaviour {

	public bool displayParticles;

	public Vector2 direction;

	public GameObject[] particleSystems;

	// Use this for initialization
	void Start () {
	
	}

	public void StopParticles(){
		foreach (GameObject particles in particleSystems) {
			particles.SetActive(false);
		}
		displayParticles = false;
	}

	// Update is called once per frame
	void Update () {
		if (!displayParticles) {

		}
		if (displayParticles) {
			if (direction == Vector2.up && particleSystems[1].activeSelf == false)
				Show(1);
			if (direction == Vector2.down && particleSystems[0].activeSelf == false)
				Show(0);
			if (direction == Vector2.right && particleSystems[3].activeSelf == false)
				Show(3);
			if (direction == Vector2.left && particleSystems[2].activeSelf == false)
				Show(2);
		}
	}

	void Show(int which){

		print ("show");
		for (int i = 0; i<particleSystems.Length; i++){
			if (i==which)
				particleSystems[i].SetActive(true);
			else
				particleSystems[i].SetActive(false);
		}
	}
}
