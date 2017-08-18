using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLife : MonoBehaviour {

	public float targetTime=2.0f;

	void Awake(){
		Destroy(gameObject,10);
	}


	// Use this for initialization
	void Start () {		
		InvokeRepeating("BlinkOff",6.0f,1.0f);
		InvokeRepeating("BlinkOn",6.5f,1.0f);
	}
	

	void BlinkOff(){
		gameObject.GetComponent<Renderer>().enabled = false;
		//Debug.Log("Off");
	}
	void BlinkOn(){
		gameObject.GetComponent<Renderer>().enabled = true;
		//Debug.Log("On");

	}




	   
}
