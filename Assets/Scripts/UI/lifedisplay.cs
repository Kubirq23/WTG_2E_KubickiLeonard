
using UnityEngine;

public class lifedisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject life;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        helth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void helth(){
        for(int i =0;i < 3;i++){
            GameObject li =Instantiate(life,transform.position + new Vector3(i*0.15f,0,0),transform.rotation,transform);
            li.name = "life"+(i+1).ToString();
        }
    }
    public void change(int HP){
        if(HP ==3){
            Destroy(GameObject.Find("life1").gameObject);
        }
        else if(HP ==2){
            Destroy(GameObject.Find("life2").gameObject);
        }
        else if(HP == 1){
            Destroy(GameObject.Find("life3").gameObject);
        }
        else{
            return;
        }
    }
}
