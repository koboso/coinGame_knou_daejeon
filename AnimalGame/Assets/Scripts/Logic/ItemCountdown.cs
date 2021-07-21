using UnityEngine;

/*
 * @class ItemCountdown
 * @desc  아이템 카운트 다운 클래스
 * @author   정성호
 * @date  2021-07-11 */

public class ItemCountdown : MonoBehaviour{
    public static float countdown = 5f;
    private TextMesh countdownText;

    void Start()    {
        countdownText = GetComponent<TextMesh>();
    }

    void Update()    {
        if (countdown <= 0f)
            countdown = 0f;
        else        {
            countdown -= Time.deltaTime;
            countdownText.text = string.Format("{0:0}", countdown);
        }
    }
}