
using UnityEngine;

public class Enemy02 : MonoBehaviour{
    [SerializeField]
    private GameObject Bomb;
    [SerializeField]
    private GameObject Column;
    private GameObject[] ExistColumns;
    private bool GoDown;
    private int Direction =1;
    private void Start(){
        CreateAliens();
    }
    private void CreateAliens(){
        for (int i = 0; i < 11; i++){
            Instantiate(Column,transform.position + new Vector3(i*0.15f,0,0),transform.rotation,transform);
        }
    }
    //movment of the ufos
    void move(){
        if(GoDown){
            transform.position+=new Vector3(0,-0.12f,0);
        }
        else{
            transform.position +=new Vector3(Direction*0.2f,0,0);
        }
        
    }
    //if the columns are touching the side rotate
    private void Rot(){
        if(ExistColumns.Length == 0)return; 
        if(GoDown) {
            GoDown =false;
            return;
        }
        if(ExistColumns[0].transform.position.x < -1.5f){
            Direction =1;
            GoDown =true;        
        }
        else if(ExistColumns[ExistColumns.Length - 1].transform.position.x > 1.5f){
            Direction =-1;
            GoDown = true;
        }

    }
     public void RefreshExistColumns(){ //nazwa, formatowanie// ???
        ExistColumns = new GameObject[gameObject.transform.childCount];
        for (int i = 0; i < ExistColumns.Length; i++){
            ExistColumns[i] = gameObject.transform.GetChild(i).gameObject;
        }
        if (ExistColumns.Length <= 0){
            Destroy(gameObject);
        }

    }
     private void Kaboom(){
        if(ExistColumns.Length == 0) return;
        int l1 = Random.Range(0,ExistColumns.Length  -1);
        int l2 = Random.Range(0,ExistColumns[l1].GetComponent<TestColumn>().columnUfos.Length -1);
        Transform loc = ExistColumns[l1].GetComponent<TestColumn>().columnUfos[l2].transform;
        var bo = Instantiate(Bomb,loc.position,loc.rotation);
        bo.name ="bomb";

    }   
        //End Game
    private void End(){
        if(ExistColumns.Length == 0){
            TestLogicMenager.instance.EndGame(true);
            enabled = false;
        }
        else{
            Gr();
        }
    }
    //End Game touching ground
    private void Gr(){
        float x = 1;
        foreach (var Column in ExistColumns){
            float y = Column.GetComponent<TestColumn>().LastUfo();
            if(y < x ){
                x = y;
            }
        }
        if(x < -0.85){
            TestLogicMenager.instance.EndGame(false);
        }
    }
    //speed ufo
    private void speeder(){

    }
    //mystery
    public void TimeOut(int nr){
        if(nr == 1){
            RefreshExistColumns();
            End();
            move();
            Rot();
            speeder();    
        }
        else{
            Kaboom();
        }
    }
}
