
using UnityEngine;

public class BunkerAnimation : MonoBehaviour{
    private float DeleyTimer,DeleyTick;
    private Vector3 pos;
    private float time ,ypos = 0.7f;
    void Start(){ 

        pos = transform.position;
        DeleyTimer = Random.Range(0.0f ,1.0f);
    }
    private void Update() {
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
        float tw = pos.y + ypos*tween(time);
        transform.position = new Vector3(transform.position.x,tw,0);
        Debug.Log(tw);
        time += 0.5f *Time.deltaTime;
        if(time > 1){
            transform.position = pos + new Vector3(0,ypos,0);
            enabled = false;
        }
    }

    private float tween(float x){
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        return 1 + c3 * (x - 1)*(x-1)*(x-1) + c1 * (x - 1)*(x - 1);
    }

}
