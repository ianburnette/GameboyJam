﻿using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player") {
			col.gameObject.GetComponent<PlayerInventory>().GetAbility();
			Destroy(gameObject);
		}
	}
}
