
using UnityEngine;
public class Fall : MonoBehaviour
{
    private float star;
    private float end;
    private float bounce;
    private float pos;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position.y;
        
    }
    private void Update() {
        transform.position =new Vector3(transform.position.x,-1 *tween(time)+1.5f + pos,transform.position.z);
        Debug.Log(transform.position.y);
        Debug.Log(tween(time));
        time += 0.5f *Time.deltaTime;
        if(time > 1){
            enabled = false;
        }
        Debug.Log("============");
    }
    private float go(){

        var l = Vector3.Lerp(new Vector3(0,star,0),new Vector3(0,end,0),time);
        return l.x;
    }
    private float tween(float x){
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        return 1 + c3 * (x - 1)*(x-1)*(x-1) + c1 * (x - 1)*(x - 1);
    }
}
