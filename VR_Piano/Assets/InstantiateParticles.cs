using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateParticles : MonoBehaviour {
	public GameObject particleSystem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			GameObject pSystem = (GameObject) Instantiate(particleSystem, transform.position, Quaternion.identity);
			pSystem.transform.eulerAngles = new Vector3(90,0,0);
			Destroy(pSystem, 5);
		}
	}
}
