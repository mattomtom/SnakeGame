using UnityEngine;
using System.Collections;
 
public class FPSCounter : MonoBehaviour
{
	float deltaTime = 0.0f;
 
	void Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float fps = 1.0f / deltaTime;
		Debug.Log(fps);
	}
}