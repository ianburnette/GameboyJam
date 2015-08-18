using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	bool haveAbility;
	PlayerSwitcher switcher;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		switcher = GetComponent<PlayerSwitcher> ();
		switcher.enabled = false;
		smoke.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetAbility(){
		haveAbility = true;
		switcher.enabled = true;
		smoke.SetActive (true);
	}
}
