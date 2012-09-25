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
	
	void Origo(){
		int x = (int)other.transform.position.x;
		int y = (int)other.transform.position.y;
		int z = (int)other.transform.position.z;
		other.transform.Translate(new Vector3(-x,-y,-z));
	}
    void Update() {
		
		if(teller == 0)
		{
			getObject ();
			Debug.Log ("Lengde av array: " + mSquare.Length);
			teller++;
		}
		if(teller ==1)
		{
			Debug.Log (other.transform.position);
			Debug.Log ("x: " + mSquare[0,0].getX() + ", y: " + mSquare[0,0].getY());
			teller++;
		}
	
		if (Input.GetMouseButtonDown(0))
		{	
			Debug.Log (other.transform.position);
			Vector3 pos0 = new Vector3(mSquare[1,0].getX()+7, mGrid.getZOffset()-1, mSquare[1,0].getY()+7);
			//Vector3 pos0 = new Vector3(10,0,0);
			//Vector3 pos0 = new Vector3(0, 0, 25);
			//other.transform.Translate(pos0);
			Origo ();
			other.transform.Translate (pos0);
			Debug.Log (other.transform.position);
			//other.transform.Translate(new Vector3(2,0,0));
		}
		if(Input.GetMouseButtonDown(1))
		{
			Origo ();
			Vector3 pos1 = new Vector3(mSquare[2,2].getX()+7, mGrid.getZOffset()-1, mSquare[2,2].getY()+7);
			other.transform.Translate(pos1);
		}
    }
}