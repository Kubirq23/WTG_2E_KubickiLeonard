
using UnityEngine;

public class bomb : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Update()
    {
        transform.position += new Vector3(0,-speed*Time.deltaTime,0);
        if(transform.position.y < -1.1f){
            Destroy(gameObject);
        }
    }
   
}
