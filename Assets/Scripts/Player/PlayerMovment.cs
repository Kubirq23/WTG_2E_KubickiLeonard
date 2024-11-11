using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public bool isfire = true;

    [SerializeField]
    private GameObject bullet;
    
    [SerializeField]
    private AudioClip st;
    [SerializeField]
    private float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Sec();
        Shot();   

    }
    //restricting player to go only on screan
    private void Sec(){
        if(transform.position.x >= 1.7f ){
            transform.position =new Vector3(1.7f,transform.position.y,transform.position.z);
        }
        else if(transform.position.x <= -1.7f){
            transform.position =new Vector3(-1.7f,transform.position.y,transform.position.z);    
        }
    }
    private void Move(){    
        float dir = Input.GetAxis("Horizontal");
        transform.position +=new Vector3(Speed*dir*Time.deltaTime,0,0);
    }
    private void Shot(){
        if(isfire == false)return;
        if(Input.GetKeyDown(KeyCode.Space) == true){
            isfire =false;
            Instantiate(bullet,transform.position,transform.rotation);
            SoundMenager.instance.SoundClip(st,transform,1);
        }
    }

}
