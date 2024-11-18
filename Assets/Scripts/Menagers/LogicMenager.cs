
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicMenager : MonoBehaviour
{
    private int HP = 4;
    public bool go;
    [SerializeField]
    private Animator PlayerAnim;
    [SerializeField]
    private Text score;
    [SerializeField]
    private BoxCollider2D bcp;
    [SerializeField]
    private PlayerMovment plm;
    [SerializeField]
    private GameObject EndScrean;
    [SerializeField]
    private Text EndText;
    [SerializeField]
    private GameObject cot;
    [SerializeField]
    private EnemyMenager em;
    private int count;
    private float licz;
    private float tick;

    private int Score;
    private void Update() {
        Tick();
    }

    public void AddScore(int points){
        Score += points;
        score.text = Score.ToString();
    } 
    public void DmgPlayer(){
        HP--;
        bcp.enabled =false;
        plm.enabled = false;
        PlayerAnim.SetBool("EndAnim", true);
    }
    public void AnimEnd(){
        Debug.Log("dd");
        bcp.enabled = true;
        plm.enabled = true;
        PlayerAnim.SetBool("EndAnim",false);
    }


    public void EndGame(bool victory){
        //em.enabled =false;
        plm.enabled =false;
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
        plm.enabled = false;
    }

    public void Back(){
        cot.SetActive(false);
        em.enabled = true;
        plm.enabled = true;
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
