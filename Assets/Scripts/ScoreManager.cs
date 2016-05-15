using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	int ScoreNumber = 0;
	int HighScoreNumber = 0;

	public Text ScoreText;
	public Text HighScoreText;

	public static ScoreManager instance = null;

	void Awake() {
		if ( instance == null ) {
			instance = this;
			HighScoreNumber = LoadHighScore();
			HighScoreText.text = HighScoreNumber.ToString();
		}
		else if ( instance != this )
			Destroy( gameObject );
	}

	public void AddScore() {
		ScoreNumber++;
		ScoreText.text = ScoreNumber.ToString();
		if ( ScoreNumber > HighScoreNumber ) {
			HighScoreNumber = ScoreNumber;
			HighScoreText.text = HighScoreNumber.ToString();
			SaveHighScore();
		}
	}

	private void SaveHighScore() {
		PlayerPrefs.SetInt( "Highscore", HighScoreNumber );
	}

	private int LoadHighScore() {
		return PlayerPrefs.GetInt( "Highscore", 0 );
	}
}
