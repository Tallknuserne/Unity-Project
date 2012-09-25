using UnityEngine;
using System.Collections;

public class UserInterface2 : MonoBehaviour {
	
	private Dice dice = new Dice();
	
	// Use this for initialization
	void Start () {
	}
	
	void OnGUI(){
		GUI.Box(new Rect(10, 10, 100, 90), "");
		
		if(GUI.Button(new Rect(20, 40, 80, 20), "Kast terning!")){
			int num = dice.getDice();
			GUI.Button (new Rect(40, 60, 80, 20), ("Din terning viser: "+num+""));
			Debug.Log("HER ER TERNINGKAST! "+num);
		}
    }
		
	// Update is called once per frame
	void Update () {

	}
}
