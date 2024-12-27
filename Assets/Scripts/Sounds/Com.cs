using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Com : MonoBehaviour //co to jest?
{
    public static bool mc = true; //co to jest?
    public void Change(){
        mc = !mc;
    }
    public bool Check(){
        return mc;
    }
}
