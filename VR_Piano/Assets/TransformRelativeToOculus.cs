using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRelativeToOculus : MonoBehaviour {
	// public GameObject camera;
	// public GameObject newParent;
	// Use this for initialization
	void Start () {
		// transform.position = camera.transform.position;
		// transform.parent = null;
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			transform.parent = null;
			// return;	
			// this.transform.position = camera.transform.position + new Vector3(2.17f, -3.7f, 1.3f);	
			// this.transform.rotation = camera.transform.rotation;
		}
	}
}
