using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCoroutine : MonoBehaviour
{
    private void OnEnable(){
        StartCoroutine(destroyCorutine());
    }
    IEnumerator destroyCorutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}