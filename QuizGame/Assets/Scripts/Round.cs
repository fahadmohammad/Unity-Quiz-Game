using UnityEngine;
using System.Collections;

[System.Serializable]
public class Round{

    public string name;
    public int timeLimitInSeconds;
    public int pointsAddedForCorrectAns;
    public QuestionData[] questions;  //class Assosiation
}
