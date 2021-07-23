using UnityEngine;
using System.Collections.Generic;
using System.Collections;
/*
 * @class Enemy
 * @desc  적군 클래스
 * @author 정성호
 * @date  2021-07-15
 */

public class Enemy : MonoBehaviour{

    // 로직 컴포넌트
    Logic logic;

    bool isLocked = false;
    public GameObject enemyObject;
    public Transform enemyLocation;
    public GameObject CollisionEffect;

    private float DestroyPosY = -7f;


    private void Awake(){
        // 로직 컴포넌트 찾아옴.
        logic=GameObject.Find("Logic").gameObject.GetComponent<Logic>();
    }

    private void OnEnable(){
        this.GetComponent<Collider2D>().enabled=true;
        isLocked=false;
    }


    void Update(){
        // 양동건.
        // 게임 플레이 상태에선 등장하지 않도록 예외처리 코드
        if (logic.state!=Logic.GameState.PLAY) return;
        transform.Translate(Vector2.down * Time.deltaTime);
        if (transform.position.y<=DestroyPosY)
        {
            this.GetComponent<Collider2D>().enabled=false;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            if (!collision.GetComponent<Player>().IsPowerMode){
                logic.CollisionPlayer();
                if (!isLocked){
                    isLocked=true;
                    Instantiate(CollisionEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
            }
            GetComponent<Collider2D>().enabled = false;
            this.gameObject.SetActive(false);
            
        }
    }


}