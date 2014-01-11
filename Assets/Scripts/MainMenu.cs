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

	}
}
