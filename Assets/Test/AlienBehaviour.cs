
using UnityEngine;

public class AlienBehaviour : MonoBehaviour{

    [SerializeField]
    private AudioClip BoomSoundClip; // nie da się domyślić po nazwie za co ta zmienna odpowiada

    [SerializeField]
    private int Value,kto;

    private void Start() {
        gameObject.GetComponent<SpriteRenderer>().color = Com.color(kto);

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")){
            TestLogicMenager.instance.AddScore(Value);
            BoomMenager.Instance.Destruction(transform.position,Com.color(kto)); 
            SoundMenager.instance.SoundClip(BoomSoundClip,transform,1);
            other.GetComponent<TestBulletControler>().Player.GetComponent<TestPlayerMovment>().canfire = true;
            Destroy(other.gameObject);
            Destroy(gameObject);    
        }
    }
}
