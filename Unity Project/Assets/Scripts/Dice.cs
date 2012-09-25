using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {
	private Dice dice;
	
	public Dice(){
	}

	public int getDice(){
		int randomNum = UnityEngine.Random.Range(1,6);
		return randomNum;
	}
	
	// Use this for initialization
	void Start () {
		dice = gameObject.GetComponent<Dice>();
	}
	
	// Update is called once per frame
	void Update () {
	/*	if(Input.GetMouseButtonDown(0)){
			Debug.Log("Øyne: " + dice.getEyes());//dice.getEyes());
		}*/
	}
}
