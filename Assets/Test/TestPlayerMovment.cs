using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerMovment : MonoBehaviour{
    public bool canfire = true;

    [SerializeField]
    private InputActionReference move, Shoot;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private AudioClip st;
    [SerializeField]
    private float Speed;


    void Update(){
        Move();
        Borders();
        Shot();
    }
    private void Borders(){
        if (transform.position.x >= 1.7f){
            transform.position = new Vector3(1.7f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -1.7f){
            transform.position = new Vector3(-1.7f, transform.position.y, transform.position.z);
        }
    }
    private void Move(){
        Vector2 dir = move.action.ReadValue<Vector2>();
        float dan = dir.x;
        transform.position += new Vector3(Speed * dan * Time.deltaTime, 0, 0);
    }
    private void Shot(){
        if (!canfire || Shoot.action.ReadValue<float>() <= 0) return;
        canfire = false;
        GameObject bu = Instantiate(bullet, transform.position, transform.rotation);
        bu.GetComponent<TestBulletControler>().Player = gameObject;

        SoundMenager.instance.SoundClip(st, transform, 1);
    }

}
