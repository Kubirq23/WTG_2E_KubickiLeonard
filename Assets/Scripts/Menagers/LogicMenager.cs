
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class LogicMenager : MonoBehaviour
{
    public bool go,isdp1,isdp2;
    [SerializeField]
    private lifedisplay ld;
    [SerializeField]
    private PlayerInput pl1in;
    [SerializeField]
    private PlayerInput pl2in;
    [SerializeField]
    private Animator Player1Anim;
    [SerializeField]
    private Animator Player2Anim;
    [SerializeField]
    private Text score;
    [SerializeField]
    private BoxCollider2D bcp1;
    [SerializeField]
    private BoxCollider2D bcp2;
    [SerializeField]
    private PlayerMovment plm1;
    [SerializeField]
    private PlayerMovment plm2;
    [SerializeField]
    private GameObject EndScrean;
    [SerializeField]
    private Text EndText;
    [SerializeField]
    private GameObject cot;
    [SerializeField]
    private EnemyMenager em;
    private int count,pl;
    private float licz;
    private float tick;
    private int HP = 4;
    private int Score;
    private void Update() {
        Tick();
    }

    public void AddScore(int points){
        Score += points;
        score.text = Score.ToString();
    } 
    public void DmgPlayer(int nr){
        if(HP >0){
            HP--;
            ld.change(HP);
        }        
        if(nr ==1){
            pl =1;
            bcp1.enabled =false;
            plm1.enabled = false;
            Player1Anim.SetBool("EndAnim", true);
        }
        else if(nr == 2){
            pl =2;
            bcp2.enabled = false;
            plm2.enabled = false;
            Player2Anim.SetBool("EndAnim", true);
        }
        else return;
    }
    
    public void AnimEnd(){
        if(pl ==1){
            bcp1.enabled = true;
            plm1.enabled = true;
            Player1Anim.SetBool("EndAnim",false);
            if(HP <= 0){
                plm1.gameObject.SetActive(false);
                isdp1 = true;
            }
        }
        else if(pl ==2){    
            if(HP <= 0){
                plm2.gameObject.SetActive(false);
                isdp2 = true;
            }
            bcp2.enabled = true;
            plm2.enabled = true;
            Player2Anim.SetBool("EndAnim",false);
        }
        if(isdp1 && isdp2){
            EndGame(false);
        }
    }


    public void EndGame(bool victory){
        em.enabled =false;
        plm1.enabled =false;
        pl1in.enabled = false;
        pl2in.enabled = false;  
        plm2.enabled =false;
        //ekran końcowy
        EndScrean.SetActive(true);
        if(victory == true){
            EndText.text ="Victory";
        }
        else{
            EndText.text = "Game Over";
        }
    }

     public void Exit(){
        Application.Quit();
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Stop(){
        cot.SetActive(true);
        em.enabled = false;
        plm1.enabled = false;
        plm2.enabled = false;
    }

    public void Back(){
        cot.SetActive(false);
        em.enabled = true;
        plm1.enabled = true;
        plm2.enabled = true;
    }

    //Score blinking
    private void Tick(){
        if(licz > tick){
            licz =0;
            Blink();
        }
        else{
            licz +=Time.deltaTime;
        }
    }
    public void Blink(){
        if(count >=5 || go == false){
            count = 0;
            go =false;
            return;
        }
        if(score.fontSize ==50){
            score.fontSize =40;
        }
        else{
            score.fontSize =50;
        }
        count++;
    }
}
