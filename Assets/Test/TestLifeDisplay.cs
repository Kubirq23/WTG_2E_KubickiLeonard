using System.Collections.Generic;
using UnityEngine;

public class TestLifeDisplay : MonoBehaviour{
    
    public Color znak;

    [SerializeField]
    private GameObject Life;
    private List<GameObject> lifelist = new List<GameObject>();
    
    public void CreateDisplay(int LifeCount){
        for (int i = 0; i < LifeCount; i++)
        {
            var life = Instantiate(Life,transform.position + new Vector3(-i*0.15f,0,0),transform.rotation,transform);
            lifelist.Add(life);
            life.GetComponent<SpriteRenderer>().color = znak;
        }
    }
    public void RemoveLife(){
        if(lifelist != null){
            Destroy(lifelist[0]);
            lifelist.RemoveAt(0);
        }
    }
}
