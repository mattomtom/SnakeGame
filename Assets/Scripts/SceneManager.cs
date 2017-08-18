using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	// Load scene with the given name in the editor	
	public void LoadScene (string  name){
		Application.LoadLevel(name);
		// Reset counter
		ScoreCounterScript.scoreValue=0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
    	    Application.Quit();
	}
}
