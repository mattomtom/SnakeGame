using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SnakeControler : MonoBehaviour {

	public GameObject SnakeTail;
	public GameObject FoodPrefab;
	public Transform TopWall;
	public Transform BottomWall;
	public Transform LeftWall;
	public Transform RightWall;

	//Slider implementation
	[Range(0.1f, 10.0f)]
	public float SpeedSlider;

	//Setting the initial direction of movement
	Vector2 direction = Vector2.up;

	//List of keeping prefabs of the tail
	List<Transform> listTail = new List<Transform>();

	//The flag defining a snake head collision with food prefab
	bool eatFlag = false;

	//Awake is called when the script instance is being loaded
	void Awake(){
		StartTail();
		FoodSpawn();
	}


	// Use this for initialization
	void Start () {
		//Invoke the function in a loop 
		InvokeRepeating("Step",10.1f-SpeedSlider,10.1f-SpeedSlider);
	}


	// Update is called once per frame
	void Update (){
		turn (); 
	}


	// Function to move the snake 
	void Step (){
		//Save current position of the snake head
		Vector2 currentPosition = transform.position;
		//Step in the desired direction, make a gap 
		transform.Translate(direction);

		// When the snake ate the food
    	if (eatFlag) {
        	// Load Prefab of the snake tail
        	GameObject newPrefab =(GameObject)Instantiate(SnakeTail,currentPosition,Quaternion.identity);

        	// Insert Prefab in the list 
        	listTail.Insert(0, newPrefab.transform);

        	eatFlag = false;
   		}
        	// Last element of the list move on the gap place
			listTail.Last().position = currentPosition;

        	// Add to front of the list, remove from the back
			listTail.Insert(0, listTail.Last());
			listTail.RemoveAt(listTail.Count-1);
	}

	// Changing the direction of movement 
	public void turn (){
		// Touch control
		Rect LeftRect = new Rect (0, 0, Screen.width / 2, Screen.height);
		Rect RightRect = new Rect (Screen.width / 2,0, Screen.width, Screen.height);
		if (Input.GetMouseButtonDown (0) && LeftRect.Contains (Input.mousePosition)) {
			//Left 
			if(direction == Vector2.up) direction = -Vector2.right;
			else if (direction == -Vector2.right) direction = -Vector2.up;
			else if (direction == -Vector2.up) direction = Vector2.right;
			else if (direction == Vector2.right) direction = Vector2.up;          
		}else if (Input.GetMouseButtonDown (0) && RightRect.Contains (Input.mousePosition)){
			//Right 
			if(direction == Vector2.up) direction = Vector2.right;
			else if (direction == Vector2.right) direction = -Vector2.up;
			else if (direction == -Vector2.up) direction = -Vector2.right;
			else if (direction == -Vector2.right) direction = Vector2.up;  
		}
	}

	// Function of collison 
	void OnTriggerEnter2D(Collider2D collider) {
    // Type of the food 
    if (collider.name.StartsWith("SpecialFood")) {
        eatFlag = true;

		ScoreCounterScript.scoreValue +=10;
        // Remove the  special food 
        Destroy(collider.gameObject);
    }
	else if  (collider.name.StartsWith("Food")) {
		eatFlag = true;

		ScoreCounterScript.scoreValue +=1;
        // Remove  the food and spawn new one
        Destroy(collider.gameObject);
        FoodSpawn();

	}
    // Collided with Tail or Border
    else {
			Application.LoadLevel("GameOver");
    }
}
	//Add 4 tail elements
	public void StartTail (){
		Vector2 Tail1= new Vector2(0.5f,-0.5f);
		Vector2 Tail2= new Vector2(0.5f,-1.5f);
		Vector2 Tail3= new Vector2(0.5f,-2.5f);
		Vector2 Tail4= new Vector2(0.5f,-3.5f);

		GameObject g1 =(GameObject)Instantiate(SnakeTail,Tail1,Quaternion.identity);
		GameObject g2 =(GameObject)Instantiate(SnakeTail,Tail2,Quaternion.identity);
		GameObject g3 =(GameObject)Instantiate(SnakeTail,Tail3,Quaternion.identity);
		GameObject g4 =(GameObject)Instantiate(SnakeTail,Tail4,Quaternion.identity);

        listTail.Insert(0, g1.transform);
		listTail.Insert(1, g2.transform);
		listTail.Insert(2, g3.transform);
		listTail.Insert(3, g4.transform);

	}
	// Generate food in a random place on the board
	public void FoodSpawn (){
		// Assign the coordinates within the boundaries of the board
		int x = (int)Random.Range(LeftWall.position.x-1,RightWall.position.x);
		int y = (int)Random.Range(BottomWall.position.y-1,TopWall.position.y);

		// Create the element with given coordinates
		Instantiate(FoodPrefab, new Vector2(x,y),Quaternion.identity);
	}
}
