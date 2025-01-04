
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class TestPlayer : MonoBehaviour{

    public int kto;
    [SerializeField]
    private GameObject lifedis;

    [SerializeField]
    private AudioClip Destruction;
    
    [SerializeField]
    private Animator animator;

    [SerializeField] 
    private BoxCollider2D boxCollider2D;
    
    [SerializeField]
    private TestPlayerMovment testPlayerMovment;
    
    [SerializeField]
    private TestLifeDisplay testLifeDisplay;
    
    [SerializeField]
    private int Life;

    private void Start(){
        var lif = Instantiate(lifedis,new Vector3(1.4f,0.7f+kto*0.1f,0),Quaternion.identity);
        testLifeDisplay = lif.GetComponent<TestLifeDisplay>();
        testLifeDisplay.znak = Com.color(kto);
        testLifeDisplay.CreateDisplay(Life -1);
        gameObject.GetComponent<SpriteRenderer>().color = Com.color(kto);
    }

    private void Hit(){
        Life --;
        Invincibility(true);
        animator.SetBool("EndAnim",true);
        if(Life <= 0){
            TestLogicMenager.instance.PlayerDead();
            Destroy(gameObject);
        }
        testLifeDisplay.RemoveLife();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("bomb")){
            Hit();
            SoundMenager.instance.SoundClip(Destruction,transform,1);
        }
    }
    private void End(){
        animator.SetBool("EndAnim",false);
        Invincibility(false);
    }
    private void Invincibility(bool isIncvincable){
        testPlayerMovment.enabled = !isIncvincable;
        boxCollider2D.enabled = !isIncvincable;
    }
}
