
using UnityEngine;

public class MysteryUfoControler : MonoBehaviour{
    [SerializeField]
    private GameObject MysteryUfo;
    private float time = 5,timer;
    private int startpos;
    private void Update(){
        Tick();
    }
    private void Tick(){
        if(time <timer){
            timer =0;
            OnTimeout();
        }
        else{
            timer += Time.deltaTime;
        }
    }
    private void OnTimeout(){
        Vector3 pozycja = new Vector3(1.79f,0.8f,0);
        startpos = Random.Range(-1,1);
        if(startpos == 0)startpos = 1;
        Debug.Log(startpos);
        pozycja.x = pozycja.x * startpos;
        time = Random.Range(13.00f,20.00f);
        GameObject ufo =Instantiate(MysteryUfo,pozycja,Quaternion.identity);
        ufo.GetComponent<SpriteRenderer>().color = Com.color(6);
    }
}
