
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool onoff;
    public float time;
    [SerializeField]
    private Enemis01 enemis01;
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
                enemis01.timeout(nr);
            }
            else{
                timer += Time.deltaTime;
            }

        }
    }
}
