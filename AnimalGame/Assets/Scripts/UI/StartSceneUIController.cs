using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUIController : MonoBehaviour
{
    // 스타트씬
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    // 인게임씬
    public void IngameScene()
    {
        SceneManager.LoadScene(1);
    }

    // 종료 버튼
    public void ExitGame()
    {
#if UNITY_ANDROID
        Application.Quit();
#elif UNITY_EDITOR
        Debug.Log("Game Quit");
#endif
    }
}


