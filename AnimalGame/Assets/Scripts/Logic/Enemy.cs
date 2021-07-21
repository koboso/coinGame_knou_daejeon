using UnityEngine;

/*
 * @class Enemy
 * @desc  적군 클래스
 * @author 정성호
 * @date  2021-07-15
 */

public class Enemy : MonoBehaviour{

    // 로직 컴포넌트
    Logic logic;

    public GameObject enemyObject;
    public Transform enemyLocation;

    private float DestroyPosY = -7f;


    private void Awake(){
        // 로직 컴포넌트 찾아옴.
        logic=GameObject.Find("Logic").gameObject.GetComponent<Logic>();
    }

    void Update(){

        // 양동건.
        // 게임 플레이 상태에선 등장하지 않도록 예외처리 코드
        if (logic.state!=Logic.GameState.PLAY) return;


        transform.Translate(Vector2.down * Time.deltaTime);

        if (transform.position.y <= DestroyPosY)
            GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            GetComponent<Collider2D>().enabled = false;
            logic.CollisionPlayer();
        }
    }
}