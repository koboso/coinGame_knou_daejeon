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
    public GameObject CollisionEffect;


    // 불필요 변수.
    //public Transform feedLocation; // 이 feed 움직인다.
    public float feedDelay; // 지연
    private float DestroyPosY = -7f;
    // 210714 추가
    private int moveSpeed; // 속도 지정

    private Logic logic = null; 

    void OnEnable(){
        this.GetComponent<BoxCollider2D>().enabled=true;
        logic=GameObject.Find("Logic").gameObject.GetComponent<Logic>();

        moveSpeed = Random.Range(0, 10);

        //Debug.Log("먹이 속도: " + moveSpeed);
    }

    void Update(){

        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        if (transform.position.y <=DestroyPosY){
            this.GetComponent<Collider2D>().enabled=false;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){            
            logic.IncreaseScore();
            this.GetComponent<Collider2D>().enabled = false;
            this.gameObject.SetActive(false);
            Instantiate(CollisionEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

}