using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParent : MonoBehaviour{

    public enum Type { UNDEFINDED =0 ,ENEMY, FEED}
    public Type objectType = Type.UNDEFINDED;


    void Start(){
        if(objectType == Type.FEED){
            // 코인 , 먹이
        }
        else{
            // 적 Enemy 일경우.
        }
    }

}
