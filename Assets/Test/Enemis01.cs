using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Enemis01 : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private LogicMenager log;
    [SerializeField]
    private GameObject al3,al2,al1,bomb;
    private int dir = 1;
    private bool dow;
    private List<List<GameObject>> mainList = new List<List<GameObject>>();
    private List<GameObject> ile = new List<GameObject>();
    private void Spawn(){

        for (int a = 0; a <11; a++){
            List<GameObject> col = new List<GameObject>();
            var al = Instantiate(al1,transform.position + new Vector3(a*0.15f,0,0),transform.rotation,transform);
            col.Add(al);
            mainList.Add(col);
            ile.Add(al);
        }
      
        for (int j = 0; j < 2; j++){          
            for( int i = 0 ; i < 11 ;i++){
                var al = Instantiate(al2,transform.position + new Vector3(i*0.15f,(j+1) * -0.15f,0),transform.rotation,transform);
                mainList[i].Add(al);
                ile.Add(al);
            }
        }
        for (int j = 0; j < 2; j++){          
            for( int i = 0 ; i < 11 ;i++){
                var al = Instantiate(al3,transform.position + new Vector3(i*0.15f,(j+3) * -0.15f,0),transform.rotation,transform);
                mainList[i].Add(al);
                ile.Add(al);
            }
        }


    }
    private void Start() {
        Spawn();
    }
    //movment of the ufos
    void move(){
        if(dow == true){
            transform.position+=new Vector3(0,-0.12f,0);
        }
        else{
            transform.position +=new Vector3(dir*0.2f,0,0);
        }
        
    }
    //if the columns are touching the side rotate
    private void Rot(){
        reload();
        if(dow ==true) {
            dow =false;
            return;
        }
        if(mainList[0][0].transform.position.x < -1.5f){
            dir =1;
            dow =true;        
        }
        else if(mainList[mainList.Count -1][0].transform.position.x > 1.5f){
            dir =-1;
            dow = true;
        }

    }
    //updating the list
    private void reload(){
        foreach (var list in mainList){//
            if(list == null)mainList.Remove(list);
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i] == null) list.RemoveAt(i);                
            }
            if(list.Count == 0){
                mainList.Remove(list);
            }
        }
        for (int i = 0; i < ile.Count; i++){
            if(ile[i] == null) ile.RemoveAt(i);
        }
    }
    //sending bombs
    private void Kaboom(){
        reload();
        if(mainList.Count == 0) return;
        int l1 = Random.Range(0,mainList.Count -1);
        int l2 = Random.Range(0,mainList[l1].Count -1);
        var loc = mainList[l1][l2].transform;
        var bo = Instantiate(bomb,loc.position,loc.rotation);
        bo.name ="bomb";

    }   
    //End Game
    private void End(){
        if(mainList.Count == 0){
            log.EndGame(true);
            enabled = false;
        }
        else{
            Gr();
        }
    }
    //End Game touching
    private void Gr(){
        float x = 1;
        foreach (var list in mainList){
            float y = list[list.Count -1].transform.position.y;
            if(y < x){
                x = y;
            }
        }
        if(x < -0.85){
            log.EndGame(false);
        }
    }

    //speed last ifo
    private void speeder(){
        if(ile.Count == 1){
            timer.time = 0.7f;
        }
        else{
            timer.time = 2- 0.02f * (55 -ile.Count);
        }
    }

    //mystery ufo

    //on tick
    public void timeout(int nr){
        if(nr == 1){
            reload();
            move();
            Rot();
            End();
            speeder();    
        }
        else{
            Kaboom();
        }
    }
    
}
