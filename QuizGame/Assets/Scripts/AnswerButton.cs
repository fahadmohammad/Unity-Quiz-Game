using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {


	[SerializeField] public Text answerText;
	private AnswerData answerData;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController>();
	}
	public void SetUp(AnswerData data)
	{
		this.answerData = data;
		answerText.text = answerData.answerText;

	}
	public void HandleClick()
	{
		gameController.AnswerButtonCLicked(answerData.isCorrect);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
