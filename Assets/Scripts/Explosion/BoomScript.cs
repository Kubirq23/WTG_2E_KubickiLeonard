
using UnityEngine;

public class BoomScript : MonoBehaviour //nazwa, Suffix "Script" jest niepotrzebny bo wiemy że to skrypt. //dla odrurznienea
{
    public void DesAnimEnd(){
        Destroy(gameObject);
    }
}
