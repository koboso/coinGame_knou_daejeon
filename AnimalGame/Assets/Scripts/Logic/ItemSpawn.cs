using System.Collections;
using UnityEngine;

/*
 * @class ItemSpawn
 * @desc  아이템 소환 클래스
 * @author 정성호
 * @date  2021-07-11 */

public class ItemSpawn : MonoBehaviour {

    Logic logic;


    public Item item;
    private MemoryPool memoryPool; // 메모리 풀
    private GameObject[] itemArray;  // 메모리 풀과 연동하여 사용할 Feed 배열
    private int itemMaxPool = 1;
    private bool itemState = false;
    private TextMesh countdownText;
    private SpriteRenderer spriteRenderer;
    private float time = 0f;

    private void Awake(){
        logic = GameObject.Find("Logic").gameObject.GetComponent<Logic>();
    }

    void Start()    {
        itemState = true;
        memoryPool = new MemoryPool();
        memoryPool.Create(item.itemObject, itemMaxPool);
        itemArray = new GameObject[itemMaxPool];
        spriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        countdownText = GetComponent<TextMesh>();
    }

    void Update()    {
        // 양동건
        // 예외 처리 코드
        if (logic.state!=Logic.GameState.PLAY) return;

        SpawnItem();
        GodMode();
    }

    private void SpawnItem()    {
        if (itemState)        {
            StartCoroutine(ItemCycleControl());

            for (int i = 0; i < itemMaxPool; i++)            {
                if (itemArray[i] == null)                {
                    itemArray[i] = memoryPool.NewItem();
                    Vector2 vector = Vector2.zero;
                    vector.x = Random.Range(-2f, 2f);
                    vector.y = 5f;
                    item.itemLocation.transform.position = vector;
                    itemArray[i].transform.position = item.itemLocation.transform.position;
                    break;
                }
            }
        }
        for (int i = 0; i < itemMaxPool; i++)        {
            if (itemArray[i])            {
                if (itemArray[i].GetComponent<Collider2D>().enabled == false)                {
                    itemArray[i].GetComponent<Collider2D>().enabled = true;
                    memoryPool.RemoveItem(itemArray[i]);
                    itemArray[i] = null;
                }
            }
        }
    }

    private void GodMode()    {
        if (Item.isEnabled)        {  // 무적 아이템을 먹으면
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            //Debug.Log(Item.isEnabled + " 활성화됨.");
            time += Time.deltaTime;
            // 무적이 됐을 때
            if (time < item.durationTime)
            {

            }

            // 무적 시간이 종료되면
            if (time > item.durationTime)            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                Item.isEnabled = false;
                time = 0;
            }
        }
    }

    IEnumerator ItemCycleControl()    {
        itemState = false;
        yield return new WaitForSeconds(3f);
        itemState = true;
    }
}