using UnityEngine;

public class bullet : MonoBehaviour //nazwy klas ( w tym plików) powinno sie pisać PascalCase
{
    //segreguj i ustawiaj pokolei zmienne
    public int wich; // nie da się domyślić po nazwie za co ta zmienna odpowiada

    [SerializeField]
    private AudioClip bom; // nie da się domyślić po nazwie za co ta zmienna odpowiada

    [SerializeField]
    private float speed;

    private PlayerMovment player;
    private PlayerMovment player2;
    private LogicMenager log; // nie da się domyślić po nazwie za co ta zmienna odpowiada

    // Start is called before the first frame update //usuwaj deafulatowe komentarze od unity
    void Start()
    {
        log = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMenager>(); //nie używaj metod Find... 
        if(!log.isdp1){
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>();
        }
        if(!log.isdp2){
            player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovment>();
        }
    }


    // if bullet goes out from screan destroy it self
    private void Update() //bądź konsekwentny i dodawaj modyfikator dostępu wszedzie.
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0); //odzielaj elementy spacjami
        if(transform.position.y > 1.1f)
        {
            dd();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //points
        if(other.name == "part"){
            dd();
            return;    
        }
        else
        {
            switch (other.tag) //przy dużej ilości else if możesz użyć switch statement. Tak czy tak nie robiłbym tego po tagach tylko za pomocą klas. 
            {
                case "Player":
                case "Player2":
                    return;
                case "row4":
                case "row3":
                    hit(10, other.transform.position, true);
                    break;
                case "row1":
                case "row2":
                    hit(20, other.transform.position, true);
                    break;
                case "row0":
                    hit(30, other.transform.position, true);
                    break;
                case "Mystery":
                    hit(300, other.transform.position, true);
                    break;
                case "":
                    hit(0, other.transform.position, false);
                    break;
            }
        }

        dd();
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    //adding points and playingt sound clip
    private void hit(int ptk, Vector3 other, bool blink)
    {
        log.AddScore(ptk);
        log.go =blink;
        BoomMenager.Instance.Destruction(other,Com.color(1)); 
        SoundMenager.instance.SoundClip(bom,transform,1);
    }

    // przenoś otwierający { nawias do kolejnej linijki, wtedy jest czytelniej
    private void dd() // nie da się domyślić po nazwie za co ta metoda odpowiada
    {
        if(wich == 1 && player != null)
        {
            player.canfire = true;

        }
        else if(wich == 2 && player2 != null)
        {
            player2.canfire = true;
        }
        else return;
    }
}
