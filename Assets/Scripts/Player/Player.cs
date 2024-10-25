
using UnityEngine;

public class Player : MonoBehaviour
{

    
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
    if(other.name =="bomb"){            
            //SoundMenager.instance.SoundClip(dmg,transform,1);
    }

    }
    public void End(){
        lg.AnimEnd();
    }
 
}
