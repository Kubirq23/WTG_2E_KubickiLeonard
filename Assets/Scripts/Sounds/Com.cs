using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Com : MonoBehaviour
{
    public static bool mc = true;
    public void Change(){
        mc = !mc;
    }
    public bool Check(){
        return mc;
    }
}
