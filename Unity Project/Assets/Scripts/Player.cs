using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Square[,] mSquare;
	private Grid mGrid;
	public int teller = 0;
	private Player other;
	
	void getObject()
	{
		mGrid =(Grid)FindObjectOfType(typeof(Grid));
		mSquare = mGrid.getSquare();
	}
	
    void Start() {
      other = gameObject.GetComponent<Player>();
    }
    void Update() {
		
		if(teller == 0)
		{
			getObject ();
			//Debug.Log ("Lengde av array: " + mSquare.Length);
			teller++;
		}
        
      	//other.transform.Rotate(new Vector3(-1, -1, -1));
		if(teller ==1)
		{
			//Debug.Log (other.transform.position);
			//Debug.Log ("x: " + mSquare[0,0].getX() + ", y: " + mSquare[0,0].getY());
			teller++;
		}
    }
}