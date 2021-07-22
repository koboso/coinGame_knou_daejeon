using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @class Player
 * @desc 플레이어 속성 클래스
 * @author  정성호
 * @date  2021-07-09 */
public class Player : MonoBehaviour
{

    private bool isPowermode = false;
    public float moveSpeed = 3.0f;
    public Vector3 moveDirection = Vector3.zero;

    public bool IsPowerMode
    {
        get { return this.isPowermode; }
    }

    // 왼쪽 이동 로직
    public bool MoveLeft(){
        if (this.transform.position.x<-1.5f) return false;

        this.transform.position-=new Vector3(moveSpeed*Time.fixedDeltaTime, 0, 0);

        return true;
    }

    // 오른쪽 이동 로직.
    public bool MoveRight(){
        if (this.transform.position.x > 1.5f) return false;

        this.transform.position += new Vector3(moveSpeed*Time.fixedDeltaTime, 0, 0);
        return true;
    }


    public void PowerMode(){
        if (isPowermode) return;
        isPowermode=true;
        StartCoroutine(PowerModeCorutine());
        StartCoroutine(PlayerColorEffectCorutine());
    }

    IEnumerator PowerModeCorutine(){
        float t = 3f;
        while (true){
            if(t <= 0) {
                this.isPowermode=false;
                StopCoroutine(PlayerColorEffectCorutine());
                break;
            }
            t-=Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator PlayerColorEffectCorutine()
    {

        while (true)
        {
            if (!this.isPowermode)
            {
                this.GetComponent<SpriteRenderer>().color=Color.white;
                break;
            }

            this.GetComponent<SpriteRenderer>().color=Color.red;
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<SpriteRenderer>().color=Color.yellow;
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<SpriteRenderer>().color=Color.green;
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<SpriteRenderer>().color=Color.blue;
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<SpriteRenderer>().color=Color.grey;
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<SpriteRenderer>().color=Color.white;

        }
    }
}

			 
															   
 

			  
							

											


						
	 
 

					  
					   

 

						  
						

 

				   
												 
																		  
								  
									 

							
 
 
  






