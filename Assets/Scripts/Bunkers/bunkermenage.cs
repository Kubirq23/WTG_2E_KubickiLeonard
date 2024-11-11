
using UnityEngine;

public class bunkermenage : MonoBehaviour
{
    [SerializeField]
    private AudioClip obr;
    [SerializeField]
    private Sprite p101;
    [SerializeField]
    private Sprite p102;
    [SerializeField]
    private Sprite p103;
    [SerializeField]
    private Sprite p201;
    public float hp;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        helth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void helth(){
        if(gameObject.tag == "bunkerp2"){
            
            hp =2;
        }
        else if(gameObject.tag == "bunkerp1"){
            hp=4;
        }
        else{
            Destroy(gameObject);
        }
    }
    private void dmg(){
        hp -=1;
        if(hp == 1 && tag == "bunkerp2"){
            sr.sprite = p201;
        }
        else if(hp == 1 && tag == "bunkerp1"){
            sr.sprite = p103;
        }
        else if(hp == 2 && tag == "bunkerp1"){
            sr.sprite = p102;
        }
        else if(hp == 3 && tag == "bunkerp1"){
            sr.sprite = p101;
        }

        if(hp == 0){
            SoundMenager.instance.SoundClip(obr,transform,1);
           Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        dmg();
        Destroy(other.gameObject);
    }
}
