using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 인게임에서 사용되는 UI Controller
public class UIController : MonoBehaviour{
    public Text countDownText;
    public GameObject[] lifeImage;
    private int lifeIndex =2;
    private Logic logic;
    // 
    private void Awake(){
        logic=GameObject.Find("Logic").gameObject.GetComponent<Logic>();
    }

    public void LifeDown(){
        if (lifeImage[lifeIndex].activeSelf){
            lifeImage[lifeIndex].gameObject.SetActive(false);
            lifeIndex--;
        }
    }

    public void InitLifeImage(){
        lifeIndex = 2;
        for(int i = 0; i< lifeImage.Length; i++){
            if (!lifeImage[i].gameObject.activeSelf){
                lifeImage[i].gameObject.SetActive(true);
            }
        }
    }

    public void SetCountDownText(int number){
        ShowCountDownText();
        this.countDownText.text=number.ToString();
    }

    // 카운트 다운 텍스트 감추기
    private void ShowCountDownText(){
        if (!this.countDownText.gameObject.activeSelf) this.countDownText.gameObject.SetActive(true);
    }

    // 카운트 다운 텍스트 보여주기.
    public void HideCountDownText(){
        if (this.countDownText.gameObject.activeSelf) this.countDownText.gameObject.SetActive(false);
    }

    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    // 인게임씬
    public void IngameScene()
    {
        SceneManager.LoadScene(1);
    }
    // 게임오버
    public void FailScene()
    {
        SceneManager.LoadScene(2);
    }
    // 헬프씬
    public void HelpScene()
    {
        SceneManager.LoadScene(3);
    }
}