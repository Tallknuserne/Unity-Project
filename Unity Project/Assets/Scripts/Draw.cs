using UnityEngine;
using System.Collections;

public class Draw : MonoBehaviour {

	private Square[,] mSquare;
	private Grid mGrid;
	private Material lineMaterial;

	void getObject(){	
		
		mGrid =(Grid)FindObjectOfType(typeof(Grid));
		mSquare = mGrid.getSquare();
		Debug.Log("Lengde:" + mSquare.Length);
		
	}
	
	void CreateLineMaterial()
	{
		getObject();
        lineMaterial = new Material ( "Shader \"Lines/Colored Blended\" {" +

            "SubShader { Pass { " +

            "    Blend SrcAlpha OneMinusSrcAlpha " +

            "    ZWrite Off Cull Off Fog { Mode Off } " +

            "    BindChannels {" +

            "      Bind \"vertex\", vertex Bind \"color\", color }" +

            "} } }" );

       lineMaterial.hideFlags  = HideFlags.HideAndDontSave;
        lineMaterial.shader.hideFlags  = HideFlags.HideAndDontSave;
			Debug.Log ("Material created");
}
	void OnPostRender() {
		
		if(!lineMaterial){
		CreateLineMaterial();}
		
		for(int i=0; i<mGrid.getMXCells(); i++)
		{
			for(int j=0; j<mGrid.getMYCells(); j++)
			{	
				Vector3 pos0 = new Vector3(mSquare[i,j].getX(), mGrid.getZOffset(), mSquare[i,j].getY());
				Vector3 pos1 =  new Vector3(mSquare[i,j].getXPlus(), mGrid.getZOffset(), mSquare[i,j].getY() );
				Vector3 pos2 = new Vector3(mSquare[i,j].getXPlus(), mGrid.getZOffset(), mSquare[i,j].getYPlus() );
				Vector3 pos3 = new Vector3(mSquare[i,j].getX(), mGrid.getZOffset(), mSquare[i,j].getYPlus() );
				lineMaterial.SetPass (0);
   				GL.Begin (GL .LINES);
   	 			GL.Color (Color.red);
				GL.Vertex(pos0);
       			GL.Vertex(pos1);
				GL.Vertex(pos1);
				GL.Vertex(pos2);
				GL.Vertex(pos2);
				GL.Vertex(pos3);
       			GL.Vertex(pos3);
				GL.Vertex(pos0);
				//Debug.Log (pos0.ToString());
				GL.End ();
			}
		}
	}
	/*void OnPostRender(){
	if(!lineMaterial){
		CreateLineMaterial();}
    lineMaterial.SetPass (0);
    GL.Begin (GL .LINES);
    GL.Color (Color.red);
    GL.Vertex3 (0, 0, 0);
    GL.Vertex3 (5, 0, 0);
    GL.Vertex3 (0, 5, 0);
    GL.Vertex3 (5, 5, 0);
    GL.Color (Color.red);
    GL.Vertex3 (0, 0, 0);
    GL.Vertex3 (0, 5, 0);
    GL.Vertex3 (5, 0, 0);
    GL.Vertex3 (5, 5, 0);
    GL.End ();
	}*/
}

/*void OnPostRender() {
     
		GL.Begin(GL.LINES);
		if(mSquare[0,0] == null)
		{
			Debug.Log ("problem");
		}
		for(int i=0; i<5; i++)
		{
			for(int j=0; j<5; j++)
			{
				if(mSquare[i,j] == null)
				{
					Debug.Log ("null at " + i + ", " +j);
				}
				Vector3 pos0 = new Vector3(mSquare[i,j].getX(), mGrid.getZOffset(), mSquare[i,j].getY());
				Vector3 pos1 =  new Vector3(mSquare[i,j].getXPlus(), mGrid.getZOffset(), mSquare[i,j].getY() );
				Vector3 pos2 = new Vector3(mSquare[i,j].getXPlus(), mGrid.getZOffset(), mSquare[i,j].getYPlus() );
				Vector3 pos3 = new Vector3(mSquare[i,j].getX(), mGrid.getZOffset(), mSquare[i,j].getYPlus() );
				
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
        
    }*/
