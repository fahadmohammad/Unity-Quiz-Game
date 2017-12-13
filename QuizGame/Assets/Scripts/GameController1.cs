using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController1 : MonoBehaviour
{

    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;


    private DataController dataController;
    private Round currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;

    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData1();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;

        UpdateTimeRemainingDisplay();

        questionIndex = 0;
        playerScore = 0;


        ShowQuestion();
        isRoundActive = true;




    }
    private void ShowQuestion()
    {
        RemoveAnswerButton();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();

            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(questionData.answers[i]);
        }
    }
    private void RemoveAnswerButton()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);

        }
    }
    public void AnswerButtonCLicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAns;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        }
        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
            //ReturnToMenu();
            EndRound();
        }
    }

    public void EndRound()
    {
        isRoundActive = false;
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
        //NextRound();
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NextRound()
    {
        //bool isCorrect = true;
        SceneManager.LoadScene("Round1");
        //Start();
        //currentRoundData = dataController.GetCurrentRoundData();
        //questionPool = currentRoundData.questions;
        //ShowQuestion();
        //AnswerButtonCLicked(isCorrect);
    }
    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();
        }
        if (timeRemaining <= 0f)
        {
            EndRound();
        }
    }
}
