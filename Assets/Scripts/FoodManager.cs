using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

	// Initialization of elements from the editor
	public GameObject SpecialFoodPrefab;
	public Renderer rend;
	public Transform TopWall;
	public Transform BottomWall;
	public Transform LeftWall;
	public Transform RightWall;

	// Use this for initialization
	void Start () {
		// Call function randomly
		Invoke("SpecialFoodRandom",Random.Range(0,10));

	}

	// Update is called once per frame
	void Update (){
		// Close the game window using the phone button 
		if (Input.GetKeyDown(KeyCode.Escape)) 
    	Application.Quit(); 
	}

	// Generate special food in a random place on the board
	void SpecialFoodRandom ()
	{	// Assign the coordinates within the boundaries of the board
		int x = (int)Random.Range (LeftWall.position.x - 1, RightWall.position.x);
		int y = (int)Random.Range (BottomWall.position.y - 1, TopWall.position.y);

		// Create the element with given coordinates
		Instantiate (SpecialFoodPrefab, new Vector2 (x, y), Quaternion.identity);

		//Loop
		Invoke("SpecialFoodRandom",Random.Range(10,20));
	}
}
