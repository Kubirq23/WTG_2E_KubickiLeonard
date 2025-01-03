using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bck : MonoBehaviour //nazwa //guzik dzwienku
{
    [SerializeField]
    private AudioSource sn;
    private void Awake() {
        BckSound(Com.mc);
    }

    public void BckSound(bool cp){
        if(!cp){
            sn.Stop();
            return;
        }
        sn.Play();

    }
}
