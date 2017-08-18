using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterScript : MonoBehaviour {

	//Counter initialization
	public static int scoreValue = 0;
	Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: "+ scoreValue;
	}


}
