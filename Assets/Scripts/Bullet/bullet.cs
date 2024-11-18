
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int wich;
    [SerializeField]
    private AudioClip bom;
    private PlayerMovment player;
    private PlayerMovment player2;
    private LogicMenager log;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        log = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMenager>();
        player = GameObject.Find("Player").GetComponent<PlayerMovment>();
        player2 = GameObject.Find("Player2").GetComponent<PlayerMovment>();
    }


    // if bullet goes out from screan destroy it self
    void Update()
    {
        transform.position += new Vector3(0,speed*Time.deltaTime,0);
        if(transform.position.y > 1.1f){
            dd();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //ponts
        if(other.name == "part"){
            dd();
            return;    
        }
        else if(other.tag == "Player"){
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
        dd();
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
    private void dd(){
        if(wich == 1){
            player.isfire = true;

        }
        else if(wich == 2){
            player2.isfire = true;
        }
        else return;
    }
}
