using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	
	private float mX;
	private float mY;
	private float mWidth;
	private float mLength;
	
	UnityEngine.GameObject mGameObject;
	
	public Square(float x, float y, float width,float length, UnityEngine.GameObject go)
	{
		this.mX = x;
		this.mY = y;
		this.mWidth = width;
		this. mLength = length;
		mGameObject = go;
	}
	
	public float getX()
	{
		return mX;
	}
	public float getY()
	{
		return mY;
	}
#region Henter ut størrelsen til brikkene
	public float getMWidth()
	{
		return mWidth;
	}
	
	public float getMLength()
	{
		return mLength;
	}
#endregion Henter ut størrelsen til brikkene
	
	public float getXPlus()
	{
		return (mX + mWidth);
	}
	
	public float getYPlus()
	{
		return (mY + mLength);
	}
	
	public string toString()
	{
		return "x: " +mX + ", y: " + mY + ", width: " + mWidth + ", Length: " + mLength + ".";
	}
	
}
