
using UnityEngine;
public class Player : MonoBehaviour
{

    [SerializeField]
    private AudioClip Destruction;
    private LogicMenager lg;
    // Start is called before the first frame update
    void Start()
    {
        lg = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMenager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag =="bomb"){    
            lg.DmgPlayer();        
            SoundMenager.instance.SoundClip(Destruction,transform,1);
        }

    }
    public void End(){
        lg.AnimEnd();
    }
 
}
