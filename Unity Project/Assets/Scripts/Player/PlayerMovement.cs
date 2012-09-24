using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	private Grid grid;
	private Square[,] square;
	private int teller = 0;
	
	private PlayerMovement player;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(teller == 0)
		{
			teller++;
			getObject();	
		}
		if (Input.GetMouseButtonDown(0))
		{	
			//FindMatrixPos();
			PlasserBrikke();
		}
	}
	
	private void getObject()
	{
		grid = (Grid)FindObjectOfType(typeof(Grid));
		square = grid.getSquare();
		player = gameObject.GetComponent<PlayerMovement>();
	}
	
	public int[] FindMatrixPos()
	{
		Vector3 playerPos = player.transform.position;
		int x_length = (int)(square[0,0].getMLength() * grid.getMXCells()); 	//lengden på brettet gitt i koordinat
		int z_length = (int)(square[0,0].getMLength() * grid.getMYCells());	//dybden på brettet gitt i koordinat
		
		int x_ = (int)playerPos.x;										//plassen til spilleren gitt i x koordinat
		int z_ = (int)playerPos.z;										//plassen til spilleren gitt i z koordinat
		
		//fare for å dele på null, men spilleren skal "aldri" være i null
		int pos_x_matrix = (int)((playerPos.x)/(x_length/grid.getMXCells()));
		int pos_z_matrix = (int)((playerPos.z)/(z_length/grid.getMYCells()));
		
		int[] intern = {pos_x_matrix , pos_z_matrix};
		
		return intern;
	}
	
	public int[] MovePlayer(int eyes)
	{
		int max_x = grid.getMXCells();
		int max_z = grid.getMYCells();
		int[] matrix = FindMatrixPos();
		int x = matrix[0];
		int z = matrix[1];
		
		if(matrix[0]%2 == 0)					//finding even numbers
		{
			if((x+eyes)>max_x)
			{
				z++;
				eyes -= max_x - x;
				
				x -= max_x - eyes;
			}
			else
			{
				x += eyes;
			}
		}
		else if(matrix[0]%2 == 1)
		{
			if((x-eyes)<0)
			{
				z++;
				eyes -= x;
				x = (eyes-1);
			}
			else
			{
				x -= eyes;
			}
		}
		matrix[0] = x;
		matrix[1] = z;
		
		return matrix;
	}
	
	public void PlasserBrikke()
	{
		int[] matrix = MovePlayer(3);
		int x_pos = (int)(matrix[0] * square[0,0].getMLength());
		int z_pos = (int)(matrix[1] * square[0,0].getMLength());
		
		Vector3 playerPos = player.transform.position; 
		player.transform.Translate(new Vector3(x_pos, 0, z_pos) - playerPos);
	}
}
