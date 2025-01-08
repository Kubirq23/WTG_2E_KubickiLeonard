
using UnityEngine;

public class LerpConroler : MonoBehaviour{
    public Vector3 StartPos,EndPos;
    [SerializeField]
    private float speed = 3;
    private float time;
    private void OnEnable() {
        time = 0;
    }
    private void Update() {
        Lerp();
    }
    private void Lerp(){
        float distance = Vector3.Distance(transform.position,EndPos);
        if(distance < 0.3f) distance = 0.3f;
        time += Time.deltaTime * distance /speed;
        Debug.Log(distance);
        transform.position = Vector3.Lerp(StartPos,EndPos,time);
        if(time >= 0.99f){
            transform.position = EndPos;
            enabled = false;
        }
    }
}
