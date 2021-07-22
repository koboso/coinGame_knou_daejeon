using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour{
    public Text scoreText;


    public void Start(){
        this.scoreText.text="Score :"+PlayerPrefs.GetInt("Score").ToString();
    }

    public void OnClickRetryGame(){
        SceneManager.LoadScene(1);
    }

    public void OnClickGoHome(){
        SceneManager.LoadScene(0);
    }


}
