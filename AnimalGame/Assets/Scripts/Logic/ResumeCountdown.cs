using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
 * @class   ResumeCountdown
 * @desc    게임 시작, 다시시작 후 카운트 다운 클래스
 * @author  정성호
 * @date    2021-07-15
 */

public class ResumeCountdown : MonoBehaviour
{
    public int countdownTime = 3;
    public Text countdownText;
    public SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        //Time.timeScale = 0f;
        Time.timeScale=1;
    }

    void Start()
    {
        //countdownText = GetComponent<Text>();
        //spriteRenderer = GameObject.FindGameObjectWithTag("CountdownPanel").GetComponent<SpriteRenderer>();

        //StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdownTime--;
        }

        countdownText.text = "Start!";

        // 이 주석 부분에 다음 씬으로 넘어가는 기능 추가

        yield return new WaitForSecondsRealtime(1f);
        spriteRenderer.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}