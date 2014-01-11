using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Highscores : MonoBehaviour {
	public List<int> unsortedHighscoreScoresList;
	public List<int> sortedHighscoreScoresList;
	public int[] highscoreScores = new int[10];
	public bool setHighscore;
	public bool getHighscore;
	public int score;
	public string name;
	public bool dead;
	void Start () {
		highscoreScores = PlayerPrefsX.GetIntArray("Scores");
		unsortedHighscoreScoresList = highscoreScores.ToList();
	}
	
	void Update () {
		if(setHighscore)
		{
			setHighscore = false;
			SetScores(name, score);
		}
		if(getHighscore)
		{
			getHighscore = false;
			Debug.Log (highscoreScores.Length);
			
		}
		
	}
	void SetScores(string name, int score)
	{
		unsortedHighscoreScoresList.Add(score);
		sortedHighscoreScoresList = unsortedHighscoreScoresList.OrderBy(i => i).ToList();
		highscoreScores = sortedHighscoreScoresList.ToArray(); 
		PlayerPrefsX.SetIntArray ("Scores", highscoreScores);
	}
	void AddScore(string name, int score){
		
		//		int newScore;
		//		string newName;
		//		int oldScore;
		//		string oldName;
		//		newScore = score;
		//		newName = name;
		
		//		for(int i=0;i<10;i++){
		//			if(PlayerPrefs.HasKey(i+"HScore")){
		//				if(PlayerPrefs.GetInt(i+"HScore")<newScore){ 
		//					// new score is higher than the stored score
		//					oldScore = PlayerPrefs.GetInt(i+"HScore");
		//					oldName = PlayerPrefs.GetString(i+"HScoreName");
		//					PlayerPrefs.SetInt(i+"HScore",newScore);
		//					PlayerPrefs.SetString(i+"HScoreName",newName);
		//					newScore = oldScore;
		//					newName = oldName;
		//				}
		//			}else{
		//				PlayerPrefs.SetInt(i+"HScore",newScore);
		//				PlayerPrefs.SetString(i+"HScoreName",newName);
		//				newScore = 0;
		//				newName = "";
		//			}
		//		}
	}
}
