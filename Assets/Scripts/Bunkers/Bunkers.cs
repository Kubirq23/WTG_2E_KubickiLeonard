using UnityEngine;

public class Bunkers : MonoBehaviour
{
    [SerializeField]
    private GameObject bunker;
    // Start is called before the first frame update
    void Start()
    {
        setbunkers();
    }

    // Update is called once per frame
    //0.7f
    void Update()
    {
        
    }
    private void setbunkers(){ //nazwa
        for (int i = 0; i < 4; i++)
        {
            Instantiate(bunker, transform.position + new Vector3(0.9f*i, 0, 0), transform.rotation,transform); //0.9f masz jako magic number, wyciągnij to do zmiennej
        }
    }
}
