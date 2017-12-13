using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

	// Use this for initialization
	public Round[] allRoundData;
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene("Menu");
	}

	public Round GetCurrentRoundData()
	{
		//for (int i = 0; i < allRoundData.Length; i++ )
		//{
			return allRoundData[0];
		//}
		//return null;
			
	}
	public Round GetCurrentRoundData1()
	{
		return allRoundData[1];
	}
	

	
	// Update is called once per frame
	void Update () {
	
	}
}
