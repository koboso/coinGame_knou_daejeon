using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @class Background
 * @desc  원근감있는 무한스크롤 클래스 (스크롤링, 패럴렉스 기법)
 * @author 정성호
 * @date  2021-07-15
 */

public class Background : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    float viewHeight;
    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
    }

    void Update()
    {

        // 예외처리 코드. 추가.
        if (sprites.Length<1) return;

        // 이동구현
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

        if (sprites[endIndex].position.y < viewHeight * (-1))

        // #.Sprite ReUse
        {
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            Vector3 frontSpritePos = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + Vector3.up * viewHeight;

            // #.Cursor Indexs Change
            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = (startIndexSave - 1 == -1) ? sprites.Length - 1 : startIndexSave - 1;

        }
    }

}