using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private Vector2 Direction;
    public AudioClip gunSound;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); 
        Animator = GetComponent<Animator>(); 
        Camera.main.GetComponent<AudioSource>().PlayOneShot(gunSound);
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }
    public void setDirection(Vector2 direction){
        Direction = direction;
    }
    public void DestroyBullet(){
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        //Alex_movement alex = collision.GetComponent<Alex_movement>();
        Grunt_Script grunt = collision.GetComponent<Grunt_Script>();
        if (grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();
    }
    
}
