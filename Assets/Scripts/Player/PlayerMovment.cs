using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovment : MonoBehaviour
{
    public bool canfire = true;

    [SerializeField]
    private InputActionReference move, Shoot;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private AudioClip st;
    [SerializeField]
    private float Speed;


    void Update()
    {
        Move();
        Sec();

    }
    private void Sec()
    {
        if (transform.position.x >= 1.7f)
        {
            transform.position = new Vector3(1.7f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -1.7f)
        {
            transform.position = new Vector3(-1.7f, transform.position.y, transform.position.z);
        }
    }
    private void Move()
    {
        Vector2 dir = move.action.ReadValue<Vector2>();
        float dan = dir.x;
        transform.position += new Vector3(Speed * dan * Time.deltaTime, 0, 0);
    }
    private void Shot(int w)
    {
        if (!canfire) return;
        canfire = false;
        GameObject bu = Instantiate(bullet, transform.position, transform.rotation);
        bu.GetComponent<bullet>().wich = w;

        SoundMenager.instance.SoundClip(st, transform, 1);
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        Shot(1);
    }
    public void OnFire1(InputAction.CallbackContext context)
    { //? co to jest?. wystarczy ci jedna metoda onfire //ktory gracz strzela
        Shot(2);
    }

}
