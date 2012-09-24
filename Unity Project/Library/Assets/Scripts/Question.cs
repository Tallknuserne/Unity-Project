using UnityEngine;
using System.Collections;

public class Question : MonoBehaviour {

	private int question_id;
	private char operationType;
	private string question;
	private string answer;
	private Hint hint; 
	
	void Start () {
	
	}
	
	public Question(int nyQuestion_id, char nyOperationType, string nyQuestion, string nyAnswer, string[] hints)
	{
		question_id = nyQuestion_id;
		operationType = nyOperationType;
		question = nyQuestion;
		answer = nyAnswer;
		hint = new Hint(hints, nyQuestion_id);
	}
	
	public void setQuestion_id(int newQuestion_id)
	{
		question_id = newQuestion_id;
	}
	
	public int getQuestion_id()
	{
		return question_id;
	}
	
	public void setOperationType(char newOperationType)
	{
		operationType = newOperationType;
	}
	
	public char getOperationType()
	{
		return operationType;
	}
	
	public void setQuestion(string newQuestion)
	{
		question = newQuestion;
	}
	
	public string getQuestion()
	{
		return question;
	}
	
	public void setAnswer(string newAnswer)
	{
		answer = newAnswer;
	}
	
	public string getAnswer()
	{
		return answer;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
