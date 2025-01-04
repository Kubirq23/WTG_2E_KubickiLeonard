
using UnityEngine;
public class MysteryScript : MonoBehaviour //nazwa nie powinna być tajemnicza // ale smiesznie
{
    [SerializeField]
    private AudioClip BoomSoundClip;
    [SerializeField]
    private float time1 = 2,timer1;
    
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
            Debug.Log("Smierc");
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
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")){
            TestLogicMenager.instance.AddScore(99);
            BoomMenager.Instance.Destruction(transform.position,Com.color(6)); 
            SoundMenager.instance.SoundClip(BoomSoundClip,transform,1);
            other.GetComponent<TestBulletControler>().Player.GetComponent<TestPlayerMovment>().canfire = true;
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
