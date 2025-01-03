
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool onoff;
    public float time;
    [SerializeField]
    private Enemy02 enemis02;
    [SerializeField]
    private int nr;
    private float timer;


    void Update()
    {
        tick(onoff);
    }

    private void tick(bool doon){
        if(!doon) return;
        else{
            if(timer > time){
                timer = 0;
                enemis02.TimeOut(nr);
            }
            else{
                timer += Time.deltaTime;
            }

        }
    }
}
