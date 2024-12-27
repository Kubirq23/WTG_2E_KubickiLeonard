
using UnityEngine;

public class BoomScript : MonoBehaviour //nazwa, Suffix "Script" jest niepotrzebny bo wiemy że to skrypt. 
{
    public void DesAnimEnd(){
        Destroy(gameObject);
    }
}
