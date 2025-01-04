
using UnityEngine;
using UnityEngine.AI;

public class TestBunkerControler : MonoBehaviour{
    [SerializeField]
    private Sprite[] sprites,sprites2;
    [SerializeField]
    private int hp,ktore;
    [SerializeField]
    private AudioClip destruction;
    private void Dmg(){
        hp--;
        if(hp == 0){
            SoundMenager.instance.SoundClip(destruction,transform,1);
            Destroy(gameObject);
            return;
        }
        if(ktore ==1){
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[hp - 1];
        }
        else if(ktore ==2 ){
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites2[hp - 1];
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("PlayerBullet")){
                Dmg();
                other.GetComponent<TestBulletControler>().Player.GetComponent<TestPlayerMovment>().canfire = true;
                Destroy(other.gameObject);
        }
        else if( other.CompareTag("bomb")){
                Dmg();
                Destroy(other.gameObject);
        }
        else if(other.CompareTag("Player")){
            return;
        }
        else{
            Destroy(gameObject);
        }
    }
}
