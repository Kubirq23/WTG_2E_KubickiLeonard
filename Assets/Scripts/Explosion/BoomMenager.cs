using System.Collections.Generic;
using UnityEngine;

public class BoomMenager : MonoBehaviour
{
    public static BoomMenager Instance {get ;private set;}

    [SerializeField]
    private GameObject DA;
    private void Awake(){
        Instance = this;
    }

    public void Destruction(Vector3 pos){
        GameObject b = Instantiate(DA,pos,transform.rotation);
    }

}
