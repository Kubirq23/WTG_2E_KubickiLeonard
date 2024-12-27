
using UnityEngine;

public class bunkermenage : MonoBehaviour //CamelCase + literówka
{
    public int hp; //to raczej powinien być int

    [SerializeField]
    private AudioClip obr;

    [SerializeField]
    private Sprite p101;

    [SerializeField]
    private Sprite p102;

    [SerializeField]
    private Sprite p103;

    [SerializeField]
    private Sprite[] bunkerSprites; // sprite można przechowywać w tablicy lub liście zamiast w kilku zmiennych
 
    [SerializeField]
    private Sprite p201;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        helth();
    }

    // Update is called once per frame
    void Update() //usuwaj metody które są puste lub ich nie używasz
    {
        
    }

    private void helth() //nazwa
    {
        if(gameObject.CompareTag("bunkerp2")) //używaj CompareTag
        {
            hp =2;
        }
        else if(gameObject.tag == "bunkerp1"){
            hp=4;
        }
        else{
            Destroy(gameObject);
        }
    }
    //nazwa
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

        //jak masz tablicę lub liste to możesz zrobić tak:
        //var spriteId = Mathf.Clamp(hp - 1, 0, bunkerSprites.Length);

        if(hp <= 0) 
        {
            SoundMenager.instance.SoundClip(obr,transform,1);
           Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        dmg();
        Destroy(other.gameObject);
    }
}
