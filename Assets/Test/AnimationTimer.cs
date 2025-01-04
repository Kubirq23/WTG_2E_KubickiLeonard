
using UnityEngine;

public class AnimationTimer : MonoBehaviour{
    [SerializeField]
    private Timer timer,btimer;
    [SerializeField]
    private TestPlayerMovment player1,player2;
    [SerializeField]
    private float time, timer2;
    private void Start() {
        Enabled(false);
    }
    private void Update() {
        if(time <timer2){
            Enabled(true);
        }
        else{
            timer2 += Time.deltaTime;
        }
    }
    private void Enabled(bool wlonczony){
        timer.enabled = wlonczony;
        btimer.enabled = wlonczony;
        player1.enabled = wlonczony;
        player2.enabled = wlonczony;
        gameObject.SetActive(!wlonczony);
    }
}
