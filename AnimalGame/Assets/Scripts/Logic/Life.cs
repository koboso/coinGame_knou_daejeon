using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * @class Life
 * @desc  목숨 클래스
 * @author 정성호
 * @date  2021-07-15
 */

public class Life : MonoBehaviour
{
    public int lifeCount = 3;

    public Text lifeText;

    void Update()
    {
        lifeText.text = lifeCount.ToString();
        Debug.Log("라이프 개수: " + lifeCount);
    }

    public void LifeDecrease()
    {
        lifeCount--;
    }

    public bool HasDied()
    {
        if (lifeCount <= 0)
            return true;
        else
            return false;
    }

    public void Dead()
    {
        SceneManager.LoadScene(2);
    }
}
