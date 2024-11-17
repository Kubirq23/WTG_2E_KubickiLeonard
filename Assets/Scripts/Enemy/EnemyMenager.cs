
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMenager : MonoBehaviour
{   
    public float descount;
    [SerializeField]
    private GameObject Mystery;
    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private GameObject column;

    [SerializeField]
    private float jmp;
    
    [SerializeField]
    private float timer2;

    [SerializeField]
    private LogicMenager log;

    private GameObject[] row1;

    private GameObject[] row2;

    private GameObject[] row3;

    private GameObject[] row4;

    private GameObject[] columns;

    private ColumNenager col;

    private float timer = 1.5f;

    private float time2;
    private float dir =1;

    private float timer3;
    private bool dow;
    private float time;

    private float time3 = 15;
    
    
    private void Start()
    {
        CreateArmy();
        log = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMenager>();

    }

    private void Update()
    {
        columns = GameObject.FindGameObjectsWithTag("columnMenager");
        if(columns.Length == 0)return;
        godown();
        end();
        MoveTimer();
        TimerSecret();
        bom();
        speedufo();
    }
    //creating 11 columns
    private void CreateArmy(){
        for (int i = 0; i < 11; i++){
            GameObject col = Instantiate(column,transform.position + new Vector3(i*0.15f,0,0),transform.rotation,transform);
            col.name =(i +1).ToString();
            
        }
    }
    //Moving timer
    private void MoveTimer(){
        
        if(time>timer){
            Move();
            Rot();
            time = 0;
        }
        else{
            time +=Time.deltaTime;
        }
    }
    private void Move(){
        if(dow == true){
            transform.position+=new Vector3(0,-0.12f,0);
        }
        else{
            transform.position +=new Vector3(dir*jmp,0,0);
        }
    }
    //rotation after touching side of screan
    private void Rot(){
        
        if(dow ==true) {
            dow =false;
            return;
        }
        if(columns[0].transform.position.x < -1.5f){
            dir =1;
            dow =true;        
        }
        else if(columns[columns.Length -1].transform.position.x > 1.5f){
            dir =-1;
            dow = true;
        }

    }
    //creating bombs
    private void bom(){
        if(time2>timer2){
            time2=0;
            sendbomb();
        }
        else{
            time2 +=Time.deltaTime;
        }
    }
    private void sendbomb(){
        if(columns == null){return;}
        int licz = Random.Range(0,columns.Length -1);
        col = columns[licz].GetComponent<ColumNenager>();
        int rad = Random.Range(0,col.als.Length -1);
        GameObject bo =Instantiate(bomb,col.als[rad].transform.position,transform.rotation);
        bo.name ="bomb";

    }
    //ending the game if there are no ufos
    private void end(){
        columns = GameObject.FindGameObjectsWithTag("columnMenager");
        if(columns.Length ==0){
            log.EndGame(true);
        }
    }
    //ending if bottom row toches player line
    private void godown(){
        row1 = GameObject.FindGameObjectsWithTag("row1");
        row2 = GameObject.FindGameObjectsWithTag("row2");
        row3 = GameObject.FindGameObjectsWithTag("row3");
        row4 = GameObject.FindGameObjectsWithTag("row4");
        if(row4.Length ==0){

            if(row3.Length == 0){

                if(row2.Length== 0){

                    if(row1.Length == 0){

                        if(transform.position.y <-0.82f){
                            log.EndGame(false);
                        }
                        return;
                        
                    }

                    if(transform.position.y <-0.68f){
                        log.EndGame(false);
                    }
                    return;
                }

                if(transform.position.y <-0.53f){
                    log.EndGame(false);
                }
                return;
            }

            if(transform.position.y <-0.38f){
                log.EndGame(false);
            }
            return;
        }
        if(transform.position.y <-0.22f){
            log.EndGame(false);
            return;
        }

    }
    //speeding last ufo
    private void speedufo(){
        if(columns.Length >1 ){
            return;
        }
        else if (columns.Length ==0){return;}
        
        GameObject cl = columns[0];
        if(cl.transform.childCount ==1){
            
            timer = 0.3f;
        }
        else{return;}
        
    }
    //special ufo timer
    private void TimerSecret(){
        if(timer3 > time3){
            timer3 =0;
            MysteryAppirence();
        }
        else{
            timer3 +=Time.deltaTime;
        }
    }
    private void MysteryAppirence(){
        int rad = Random.Range(1,3);
        time3 = Random.Range(8,15);
        if(rad >= 2){
            rad = -1;
        }
        Instantiate(Mystery,new Vector3(rad*1.7f ,0.7f,0),transform.rotation);
    }
}
