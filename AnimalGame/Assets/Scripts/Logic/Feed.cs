using UnityEngine;

/**
 * @class
 * @desc  먹이(코인 등) 관련 클라스
 * @author   정성호
 * @date  2021-07-09
 */
public class Feed : MonoBehaviour
{
    public GameObject feedObject; // feed라는 프리펩 찾기

    // 불필요 변수.
    //public Transform feedLocation; // 이 feed 움직인다.
    public float feedDelay; // 지연
    public float DestroyPosY = -7f;
    // 210714 추가
    private int moveSpeed; // 속도 지정

    void OnEnable(){
        moveSpeed = Random.Range(0, 10);

        //Debug.Log("먹이 속도: " + moveSpeed);
    }

    void Update(){

        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        if (transform.position.y <= DestroyPosY)
            GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("코인먹음");
            GetComponent<Collider2D>().enabled = false;
            Score.score += ChoiceScore(moveSpeed);
        }
    }

    // 속도에 따른 점수
    private int ChoiceScore(int moveSpeed)
    {
        int score = 0;

        if (moveSpeed <= 3)
            score = 1;

        if (moveSpeed > 3 && moveSpeed <= 7)
            score = 5;

        if (moveSpeed > 7 && moveSpeed < 10)
            score = 10;

        return score;
    }
}