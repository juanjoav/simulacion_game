using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Direction * speed;
        
    }

    public void SetDirection(Vector2 direction) { 
        Direction = direction;
    }

    public void DestroyBullet() { 
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Alex_movement alex = collision.collider.GetComponent<Alex_movement>();
        if(collision.collider.GetComponent<WaterBullet>() != null){
            Debug.Log("Choque Entre Botellas");
        }else if (alex != null) {
            Debug.Log("Choque"); 
            alex.IncreaseHealth();
            DestroyBullet();
        }else{
            DestroyBullet();
        }
    }
}
