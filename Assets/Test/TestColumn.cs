
using UnityEngine;

public class TestColumn : MonoBehaviour{

    public GameObject[] columnUfos ;

    [SerializeField]
    private GameObject al1,al2,al3;

    private void Start() {
        CreateColumn();    
    }
    private void Update() {
        RefreshColumn();
    }
    private void CreateColumn(){
        GameObject al = al1;
        for (int i = 0; i < 5; i++){
            Instantiate(al,transform.position+ new Vector3(0,i*-0.15f,0),transform.rotation,transform);
            if(i == 0 || i ==1) al = al2;
            else al = al3;
            
        }
    }
    public void RefreshColumn(){ //nazwa, formatowanie// ???
        columnUfos = new GameObject[gameObject.transform.childCount];
        for (int i = 0; i < columnUfos.Length; i++){
            columnUfos[i] = gameObject.transform.GetChild(i).gameObject;
        }
        if (columnUfos.Length <= 0){
            Destroy(gameObject);
        }
    }
    public float LastUfo(){
        if(columnUfos.Length == 0) return 1;
        if(columnUfos[columnUfos.Length -1] == null && columnUfos.Length >=2)return columnUfos[columnUfos.Length -2].transform.position.y;
        return columnUfos[columnUfos.Length -1].transform.position.y;
    }
}
