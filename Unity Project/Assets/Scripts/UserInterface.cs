using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour {
	
	private Dice dice = new Dice();
	private GameObject target;
	private PlayerMovement pm;
	private bool bol = true;
	
	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag("Player");
		if(target != null) Debug.Log("Spiller funnet: " + target.tag);
	}
	
	void OnGUI(){
		GUI.Box(new Rect(10, 10, 100, 90), "");
		
		if(GUI.Button(new Rect(20, 40, 80, 20), "Kast terning!")){
			//int num = dice.getDice();
			//GUI.Button (new Rect(40, 60, 80, 20), ("Din terning viser: " + num + ""));
			//Debug.Log("HER ER TERNINGKAST! " + num);
			
			int terning = pm.KastTerning(dice.ThrowDice);	
		}
    }
	// Update is called once per frame
	void Update () {
		if(bol)
		{
			pm = (PlayerMovement)FindObjectOfType(typeof(PlayerMovement));
			bol = false;
		}
	}
}
