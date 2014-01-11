using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class MainMenu : MonoBehaviour {
	public List<int> unsortedHighscoreScoresList;
	public List<int> sortedHighscoreScoresList;
	public int[] highscoreScores = new int[10];
	public string[] highscoreNames = new string[10];
	void Start () {
		highscoreScores = PlayerPrefsX.GetIntArray("HighscoreScores");
		highscoreNames = PlayerPrefsX.GetStringArray("HighscoreNames");
//		unsortedHighscoreScoresList = highscoreScores.ToList();
//		sortedHighscoreScoresList = unsortedHighscoreScoresList.OrderBy(i => i).ToList();
//		highscoreScores = sortedHighscoreScoresList.ToArray(); 
	}
	

	void Update () {
	
	}

	void OnGUI()
	{ 


		if(GUILayout.Button ("StartGame")) 
		{

			Application.LoadLevel("PlayScene");
		}

		for(int i = 0; i< highscoreNames.Length; i++) 
		{
			GUI.Label(new Rect(Screen.width/2 -100, Screen.height/2-50 +i*15, 200, 100),highscoreScores[i].ToString());
			GUI.Label(new Rect(Screen.width/2 -200, Screen.height/2-50+i*15, 200, 100),highscoreNames[i].ToString());
		}
		
	}
	//Fiskedusen
}
