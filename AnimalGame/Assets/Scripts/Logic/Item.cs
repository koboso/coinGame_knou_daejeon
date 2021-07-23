using UnityEngine;

/*
 * @class Item
 * @desc  아이템 클래스
 * @author 정성호
 * @date  2021-07-11
 */
public class Item : MonoBehaviour {
    public GameObject itemObject; // 아이템 오브젝트
    public Transform itemLocation;// 아이템 생성 위치
    public float durationTime;    // 아이템 지속 시간
    public static bool isEnabled; // 아이템 활성화 상태
    public GameObject CollisionEffect;
    private bool isLocked = false;

    private float DestroyPosY = -5f;

   

    void Update() {
        transform.Translate(Vector2.down * Time.deltaTime);

        if (transform.position.y <= DestroyPosY)
            GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)    {
        if (collision.CompareTag("Player")){
            if (!collision.GetComponent<Player>().IsPowerMode){

                GameObject player = collision.gameObject;

                collision.GetComponent<Player>().PowerMode();
                if (!isLocked){
                    isLocked=true;
                    Instantiate(CollisionEffect, player.transform.position, Quaternion.identity);
                }
            }
            GetComponent<Collider2D>().enabled = false;
        }
        // 획득시 효과음 발생
    }
}