using UnityEngine;
using System.Collections;
using System.Collections.Generic;	


	

public class Hint : MonoBehaviour {
	
	//Define the array
	public string[] hints;
	//The length of the array
	public int lengthOfArray = 2;
	//The question_Id for the hints
	public int question_id;
	// Use this for initialization
	
	public Hint(string[] nyHints, int nyQuestion_id)
	{
		hints = nyHints;
		question_id = nyQuestion_id;
	}
	void Start () {
		
		//Sets the array
		hints = new string[lengthOfArray];
		hints[0] = "Hei din bamse";
	
	}
	
	public void setQuestion_id(int newQuestion_id)
	{
		question_id = newQuestion_id;
	}
	
	public int getQuestion_id()
	{
		return question_id;
	}
	
	
	// Update is called once per frame
	void Update () {
		Debug.Log (hints[0]);
	
	}
}
