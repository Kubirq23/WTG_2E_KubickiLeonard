
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private AudioClip bom;
    private PlayerMovment player;
    private LogicMenager log;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        log = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMenager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>();
    }

    // if bullet goes out from screan destroy it self
    void Update()
    {
        transform.position += new Vector3(0,speed*Time.deltaTime,0);
        if(transform.position.y > 1.1f){
            player.isfire =true;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //ponts
        if(other.name == "part"){
            player.isfire =true;
            return;    
        }
        else if(other.name == "Player"){
            return;
        }
        else if(other.tag == "row4" || other.tag == "row3"){
            hit(10,other.transform.position,true);
        }
        else if(other.tag == "row1" || other.tag == "row2"){
            hit(20,other.transform.position,true);
        }
        else if(other.tag == "row0"){
            hit(30,other.transform.position,true);            
        }
        else if(other.tag == "Mystery"){
            hit(300,other.transform.position,true);
        }
        else if(other.tag == ""){
            hit(0,other.transform.position,false);
        }
        player.isfire =true;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
    //adding points and playingt sound clip
    private void hit(int ptk,Vector3 other,bool blink){
        log.AddScore(ptk);
        log.go =blink;
        BoomMenager.Instance.Destruction(other); 
        SoundMenager.instance.SoundClip(bom,transform,1);
    }
}
