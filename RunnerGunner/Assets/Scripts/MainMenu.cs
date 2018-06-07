using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text highScoreText;
	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 30;
        highScoreText.text = "High Score : " + (int)PlayerPrefs.GetFloat("Highscore");
	}
	
    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
