using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {

	public bool key;
	public doorScript door;
	public GameObject ui;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Head" || col.transform.tag == "Player") {
			if (key){
				door.haveKey = true;
				col.SendMessage("GetKey");
				GetComponent<SpikeActivator>().Activate();
				col.GetComponent<health>().SavePosition();
			}else{
				col.gameObject.GetComponent<PlayerInventory>().GetAbility();
				ui.SetActive(true);
			}

			Destroy(gameObject);
		}
	}
}
