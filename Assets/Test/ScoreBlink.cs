
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ScoreBlink : MonoBehaviour{
    public int count;
    
    [SerializeField]
    private Text text;

    [SerializeField]
    private float time = 0.5f ,timer;
    private void Update() {
        if (time < timer){
            Blink();    
            timer = 0;
        }
        else{
            timer += Time.deltaTime;
        }

    }
    private void Blink(){
        count++;
        if(count > 6) {
            count = 0; 
            enabled = false;
        }
        if(count % 2 == 1 ){
            text.fontSize = 40;
        }
        else{
            text.fontSize = 30;
        }
    }
}
