
using UnityEngine;

public class TestBulletControler : MonoBehaviour{
    public GameObject Player;

    [SerializeField]
    private float speed;
    
    private void Update() {
        Move();
    }
    
    private void Move(){
        transform.position += new Vector3(0, speed * Time.deltaTime, 0); //odzielaj elementy spacjami
        if(transform.position.y > 1.1f){
            EndLife();
        }
    }

    private void EndLife(){
        Player.GetComponent<TestPlayerMovment>().canfire = true;
        Destroy(gameObject);
    }
}
