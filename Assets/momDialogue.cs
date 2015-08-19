using UnityEngine;
using System.Collections;

public class momDialogue : MonoBehaviour {

	public GameObject[] dialogues;
	public int dialogueIndex;
	public GameObject finalDialogue;
	public float endTime = 3f;

	public finalDoor doorScript;

	public GameObject nextToLastDoor;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			NextIndex();
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.transform.tag == "Head") {
			finalDialogue.SetActive(true);
			Invoke ("EndSequence", endTime);
		}
	}

	void NextIndex(){
		dialogueIndex++;
		if (dialogueIndex <= dialogues.Length) {
			for (int i = 0; i < dialogues.Length; i++) {
				if (i == dialogueIndex) {
					dialogues [i].SetActive (true);
				} else {
					dialogues [i].SetActive (false);
				}
				if (dialogueIndex == dialogues.Length){
					nextToLastDoor.SetActive(false);
				}
			}
		} else {
			foreach (GameObject dia in dialogues){
				dia.SetActive(false);
				nextToLastDoor.SetActive(false);
			}
		}
	}

	void EndSequence(){
		doorScript.GoToRoom ();
	}
}
