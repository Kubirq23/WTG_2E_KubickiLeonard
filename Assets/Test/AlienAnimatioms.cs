using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAnimatioms : MonoBehaviour
{
    private float DeleyTimer,DeleyTick;
    private float pos;
    private float time = 0;
    void Start(){ 

        pos = transform.position.y;
        transform.position += new Vector3(0,2,0);
        DeleyTimer = Random.Range(0.0f ,1.0f);
    }
    private void Update() {
        Debug.Log(DeleyTimer);
        Deley();
    }
    private void Deley(){
        if(DeleyTimer<DeleyTick){
            TweenMove();
        }
        else{
            DeleyTick += Time.deltaTime;
        }
    }
    private void TweenMove(){
        transform.position =new Vector3(transform.position.x,-1 *tween(time)+1.5f + pos,transform.position.z);

        time += 0.5f *Time.deltaTime;
        if(time > 1){
            enabled = false;
        }
    }

    private float tween(float x){
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        return 1 + c3 * (x - 1)*(x-1)*(x-1) + c1 * (x - 1)*(x - 1);
    }
}
