using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	
	//Define a Terrain object
	Terrain mTerrain;
	Camera camera1;
	
	private TerrainData mTData;
	private int mTerrainWidth;
	private int mTerrainLength;
	private int mXCells = 5;
	private int mYCells = 5;
	private float mTileWidth;
	private float mTileLength;
	private Square[ , ] mSquare;
	//private LineRenderer lineRenderer;
	public static int zOffset = 1;
	private GameObject newGo;

	// Use this for initialization
	void Start () {
		
		mTerrain = this.GetComponent <Terrain>();
		/*lineRenderer = gameObject.AddComponent<LineRenderer>();
		
		lineRenderer.SetVertexCount(5);
		if(lineRenderer == null)
		{
			Debug.Log ("null lineRenderer");
		}else {Debug.Log("lineRenderer");}*/
		
		mTData = mTerrain.terrainData;
	
		mTerrainWidth = (int)mTData.size.x;
		mTerrainLength = (int)mTData.size.z;
		
		//Debug.Log("Terrain Width: " + mTerrainWidth);
		//Debug.Log("Terrain Length: " + mTerrainLength);
			
		mTileWidth = (mTerrainWidth / mXCells);
		mTileLength = (mTerrainLength / mYCells);
		//Debug.Log ("Tile Width: " + mTileWidth);
		//Debug.Log ("Tile length: " + mTileLength);
		
		mSquare = new Square[mXCells, mYCells];
		
		//legger object i den todimensjonale Square tabellen
		GL.Begin(GL.LINES);
		for (int i = 0; i < mXCells; i++)
		{
			for (int j = 0; j < mYCells; j++)
			{
				
				mSquare[i,j] =new Square( (i*mTileWidth), (j*mTileLength), mTileWidth, mTileLength, this.gameObject); 
			}
		}		
		//Writing out the toString for every Square object
		for(int i =0; i<mXCells; i++)
		{
			for(int j = 0; j<mYCells; j++)
			{
				//Debug.Log (mSquare[i,j].toString ());
			}
		}	
		//Debug.Log (mSquare.Length);
		
			
		
	}
	
	public int getZOffset()
	{
		return zOffset;
	}
	
	public int getMXCells()
	{
		return mXCells;
	}
	
	public int getMYCells()
	{
		return mYCells;
	}
	
	public Square[,] getSquare()
	{
		return mSquare;
	}
	
	/* void Update(){
		GL.Begin(GL.LINES);
		
		for(int i=0; i<mXCells; i++)
		{
			for(int j=0; j<mYCells; j++)
			{
				//if(mSquare[i,j] == null)
				//{
				//	Debug.Log ("null at " + i + ", " +j);
				//}
				//Debug.Log(mSquare[i,j].getX());
				Vector3 pos0 = new Vector3(mSquare[i,j].getX(), zOffset, mSquare[i,j].getY());
				Vector3 pos1 =  new Vector3(mSquare[i,j].getXPlus(), zOffset, mSquare[i,j].getY() );
				Vector3 pos2 = new Vector3(mSquare[i,j].getXPlus(), zOffset, mSquare[i,j].getYPlus() );
				Vector3 pos3 = new Vector3(mSquare[i,j].getX(), zOffset, mSquare[i,j].getYPlus() );
				GL.Color (Color.red);
				GL.Vertex(pos0);
       			GL.Vertex(pos1);
				GL.Vertex(pos1);
				GL.Vertex(pos2);
				GL.Vertex(pos2);
				GL.Vertex(pos3);
       			GL.Vertex(pos3);
				GL.Vertex(pos0);	
			}
		}
        //Debug.Log (mSquare[0,0].toString ());
        GL.End();
        
    }
	void Update()
	{
		for(int i=0; i<mXCells; i++)
		{
			for(int j=0; j<mYCells; j++)
			{
				Vector3 pos0 = new Vector3(mSquare[i,j].getX(), zOffset, mSquare[i,j].getY());
				Vector3 pos1 =  new Vector3(mSquare[i,j].getXPlus(), zOffset, mSquare[i,j].getY() );
				Vector3 pos2 = new Vector3(mSquare[i,j].getXPlus(), zOffset, mSquare[i,j].getYPlus() );
				Vector3 pos3 = new Vector3(mSquare[i,j].getX(), zOffset, mSquare[i,j].getYPlus() );
				
				lineRenderer.SetWidth(10,10);
				lineRenderer.SetColors(Color.red, Color.red);
				
				lineRenderer.SetPosition(0, pos0);
				lineRenderer.SetPosition(1, pos1);
				lineRenderer.SetPosition(2, pos2);
				lineRenderer.SetPosition(3, pos3);
				lineRenderer.SetPosition(4, pos0);
				//lineRenderer.SetPosition ();	
			}
		}
		//Debug.Log ("Rendered Line");	
	}*/
	// Update is called once per frame	
}
