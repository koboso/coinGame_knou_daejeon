using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @class Logic
 * @desc 로직 클래스
 * @author  정성호
 * @date  2021-07-09 */

public class Logic : MonoBehaviour {
    // 게임 카운트 다운.

    private UIController uiController;
    public GameObject uiCanvas;

    private float countDownNumber = 5.4f;
    private enum Direction { STOP = 0, LEFT, RIGHT };
    Direction dir = Direction.STOP;
    // 생명력.
    private int hp = 2;
    // 게임 전체적인 상태값을 가지고 있는 공용체
    public enum GameState { NONE = 0, READY, PLAY, FAIL }
    public GameState state = GameState.NONE;

    // 게임 스코어
    private int gameScore = 0;

    // 플레이어 객체
    private GameObject player;

    private void Awake() {
        uiController=uiCanvas.GetComponent<UIController>();
    }

    void Update() {
        GameLogic();
    }

    private void Init() {
        player=GameObject.Find("JSH_Player").gameObject;
        state=GameState.READY;
        gameScore = 0;
        InitHp();
        uiController.InitLifeImage();
    }

    // 실질적인 게임로직 함수.
    private void GameLogic() {
        switch (state) {
            case GameState.NONE: Init(); break;
            case GameState.READY: CountDown(); break;
            case GameState.PLAY: PlayerController(); break;
            case GameState.FAIL: uiController.FailScene(); break;
        }
    }

    // 상태값 바꿔주는 함수.
    public void SetState(Logic.GameState state) {
        this.state=(GameState)state;
    }

    public int Hp {
        get {
            return this.hp;
        }
    }

    // 플레이어가 어딘가에 충돌했을때 
    public void CollisionPlayer() {
        if (hp<1) SetState(Logic.GameState.FAIL);
        hp-=1;
        uiController.LifeDown();
    }

    public void InitHp() {
        hp=2;
    }

    private void CountDown(){
        if (this.countDownNumber<=0)
        {
            uiController.HideCountDownText();
            state=GameState.PLAY;
        }
        else{
            countDownNumber-=Time.fixedDeltaTime;
            // 타입 캐스팅(정수)
            int number = (int)countDownNumber;
            uiController.SetCountDownText(number);
        }
        
    }

    // 플레이어 컨트롤 관리하는 함수
    private void PlayerController(){
       // 플랫폼 구분
#if UNITY_EDITOR
        // 에디터 마우스 컨트롤.
        if (Input.GetMouseButton(0)){
            Vector3 vc = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if(vc.x > 0.5f) dir = Direction.RIGHT;
            else dir=Direction.LEFT;
            PlayerMovement(dir);
        }
#else
        // 안드로이드 터치 컨트롤
        if (Input.touchCount>=1){
            Vector3 vc = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
            if (vc.x>0.5f) dir=Direction.RIGHT;
            else dir=Direction.LEFT;
            PlayerMovement(dir);
        }
#endif

    }
    private void  PlayerMovement(Direction dir){
        if(dir == Direction.LEFT){
            if (!player.GetComponent<Player>().MoveLeft()){
                dir=Direction.STOP;
            }
        }
        else if(dir ==Direction.RIGHT){
            if (!player.GetComponent<Player>().MoveRight()){
                dir=Direction.STOP;
            }
        }

    }
}
