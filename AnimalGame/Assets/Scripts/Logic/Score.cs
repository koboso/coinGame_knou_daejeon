using UnityEngine;
using UnityEngine.UI;

/*
 * @class Score
 * @desc  스코어 출력 클래스
 * @author   정성호
 * @date  2021-07-11 */
   
public class Score : MonoBehaviour {
    public static int score = 0;
    private Text scoreText;

    void Start()    {
        scoreText = GetComponent<Text>();
    }

    void Update()    {
        scoreText.text = "Score: " + score;
    }
}