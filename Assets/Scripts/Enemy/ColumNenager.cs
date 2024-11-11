
using UnityEngine;

public class ColumNenager : MonoBehaviour
{
    [SerializeField]
    private GameObject alien;

    [SerializeField]
    private GameObject alien20;

    [SerializeField]
    private GameObject alien10;

    private GameObject col;

    public GameObject[] als;



    // Start is called before the first frame update
    void Start()
    {
        AlienCol();
        col = GameObject.Find(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        check();
    }


    //creating column
    private void AlienCol(){
        GameObject al = Instantiate(alien,transform.position + new Vector3(0,-0*0.15f,0),transform.rotation,transform);
        al.tag = "row0";
        al.name = "Alien0";

        for(int i = 0; i < 2; i++){
            al = Instantiate(alien20,transform.position + new Vector3(0,-(i+1)*0.15f,0),transform.rotation,transform);
            al.tag = "row"+ (i+1).ToString();
            al.name = "Alien" + (i+1).ToString();
        }

        for(int i = 0; i < 2; i++){
            al = Instantiate(alien10,transform.position + new Vector3(0,-(i+3)*0.15f,0),transform.rotation,transform);
            al.tag = "row"+ (i+3).ToString();
            al.name = "Alien" + (i+3).ToString();
        }
    }
    //if column is empty - destroy
    private void check(){
        als = new GameObject[col.transform.childCount];
        for (int i = 0; i < als.Length; i++){
            als[i] = col.transform.GetChild(i).gameObject;
        }
        if(als.Length <= 0){
            Destroy(gameObject);
        }
        else{
            return;
        }
    }
}
