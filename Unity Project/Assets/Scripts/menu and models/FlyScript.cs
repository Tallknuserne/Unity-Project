using UnityEngine;
using System.Collections;

public class FlyScript : MonoBehaviour {
	
	private FlyScript fly;
	
	// Use this for initialization
	void Start () {
		
		fly = gameObject.GetComponent<FlyScript>();
	}
	// Update is called once per frame
	void Update () {
	
		if(fly.transform.position.z>= 25)
		{
			fly.transform.Translate(new Vector3(10,0,0) * Time.deltaTime*2);
			
		}else if(fly.transform.position.y>=10) {fly.transform.Translate (new Vector3(0,-2,0) * Time.deltaTime * 2);}
	
	}
}
