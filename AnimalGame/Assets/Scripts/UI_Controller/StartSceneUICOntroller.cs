using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @class StartSceneUICOntroller
 * @desc  스타트씬 UI 컨트롤 클래스
 * @author 정성호
 * @date  2021-07-21
 */

public class StartSceneUICOntroller : MonoBehaviour
{

    // 스타트씬
    public void StartScene(){
        SceneManager.LoadScene(0);
    }

    // 인게임씬
    public void IngameScene(){
        SceneManager.LoadScene(1);
    }

    // 게임오버
    public void FailScene(){
        SceneManager.LoadScene(2);
    }
    // 종료 버튼
    public void ExitGame(){
#if UNITY_ANDROID
        Application.Quit();
#elif UNITY_EDITOR
        Debug.Log("Game Quit");
#endif
    }
}