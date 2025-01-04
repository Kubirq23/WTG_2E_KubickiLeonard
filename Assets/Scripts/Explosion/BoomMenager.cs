using System.Collections.Generic;
using UnityEngine;

public class BoomMenager : MonoBehaviour //nazwa
{
    public static BoomMenager Instance {get ;private set;}

    [SerializeField]
    private GameObject DA; //nazwa
    private void Awake()
    {
        if (Instance == null) //zabezpieczenie singletona na wypadek, gdyby był drugi na scenie // zapomialem
        {
            Instance = this;
        } else Destroy(Instance.gameObject);
    }

    public void Destruction(Vector3 pos,Color color){
        GameObject b = Instantiate(DA,pos,transform.rotation);
        b.GetComponent<SpriteRenderer>().color = color;
    }

}
