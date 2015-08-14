using UnityEngine;
using System.Collections;

public class HeadGravity : MonoBehaviour {

	public Animator anim;
	public GameObject particles;

	public void SwitchDirection(int dir){
		anim.SetInteger ("dir", dir);
	}

	public void ToggleParticles(bool onOrOff){
		particles.SetActive (onOrOff);
	}
}
