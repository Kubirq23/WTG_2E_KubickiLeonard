using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryUfoControler : MonoBehaviour
{
    [SerializeField]
    private GameObject MysteryUfo;
    private float time = 5,timer;

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
        if(Random.Range(1,2) == 2){
            pozycja.x = pozycja.x * -1;
            Debug.Log(pozycja);
        }
        time = Random.Range(10.00f,20.00f);
        GameObject ufo =Instantiate(MysteryUfo,pozycja,Quaternion.identity);
        ufo.GetComponent<SpriteRenderer>().color = Com.color(6);
    }
}
