
using UnityEngine;

public class LogicMenager : MonoBehaviour
{
    private int HP = 4;
    private Animator PlayerAnim;
    public void DmgPlayer(){
        HP--;
        if(HP == 0){

        }
        PlayerAnim.SetBool("DesAnim", true);
    }
    public void AnimEnd(){
        PlayerAnim.SetBool("DesAnim",false);
    }
}
