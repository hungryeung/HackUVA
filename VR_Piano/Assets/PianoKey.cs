using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour {
	public AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	void OnCollisionEnter(Collision collision){
		Debug.Log(collision.collider.tag);
		if(collision.collider.tag == "backboard"){
			audio.Play();
		}
	}
}
