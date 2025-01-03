
using UnityEngine;

public class AlienBehaviour : MonoBehaviour{

    [SerializeField]
    private AudioClip BoomSoundClip; // nie da się domyślić po nazwie za co ta zmienna odpowiada

    [SerializeField]
    private int Value,kto;
    private float pos;
    private float time = 0;
    void Start(){ 
        pos = transform.position.y;
        gameObject.GetComponent<SpriteRenderer>().color = Com.color(kto);
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
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")){
            TestLogicMenager.instance.AddScore(Value);
            Debug.Log("Alien--------------------");
            BoomMenager.Instance.Destruction(transform.position); 
            SoundMenager.instance.SoundClip(BoomSoundClip,transform,1);
            other.GetComponent<TestBulletControler>().Player.GetComponent<TestPlayerMovment>().canfire = true;
            Destroy(other.gameObject);
            Destroy(gameObject);    
        }
    }
}
