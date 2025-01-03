
using UnityEngine;
public class MysteryScript : MonoBehaviour //nazwa nie powinna być tajemnicza // ale smiesznie
{
    [SerializeField]
    private float time1 = 2;
    private float timer1;
    private int x;

    void Start()
    {
        time1 = 0.2f;
        if(transform.position.x >0){
            x =-1;
        }
        else{
            x=1;
        }
    }

    void Update()
    {
        destuction();
        timer();
    }
    private void destuction(){
        if(transform.position.x >= 1.8f || transform.position.x <= -1.8f){
            Destroy(gameObject);
        }
    }
    private void timer(){
        if(timer1 >time1){
            transform.position += new Vector3(x*0.1f,0,0);
            timer1 = 0;
        }
        else{
            timer1+=Time.deltaTime;
        }
    }
}
