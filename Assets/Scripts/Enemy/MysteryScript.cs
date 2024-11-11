
using UnityEngine;
public class MysteryScript : MonoBehaviour
{
    [SerializeField]
    private float time1 = 2;
    private float timer1;
    private int x;
    // Start is called before the first frame update
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

    // Update is called once per frame
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
        Debug.Log(time1);
        if(timer1 >time1){
            transform.position += new Vector3(x*0.1f,0,0);
            timer1 = 0;
        }
        else{
            timer1+=Time.deltaTime;
        }
    }
}
