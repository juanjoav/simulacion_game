using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Script : MonoBehaviour
{
    public GameObject Alex;
    public GameObject BulletPrefabEnemy;

    private float LastShoot;
    private float LastMove;
    private float sliderVidas = 40;
    private float timeElapsed;
    public float movementSpeed = 2f; 
    public float threshold = 50f;

    public static event System.Action OnEnemyEliminated;

    private float semilla;
    private const long a = 1103515245;
    private const long c = 12345;
    private const long m = 2147483648;
    
    void Start()
    {
        Debug.Log(Time.deltaTime); 
        semilla = Random.Range(0f, 10000f);
        Debug.Log("Semilla:  " + semilla); 
        Alex = GameObject.Find("Alex");

    }

    void Update()
    {
    timeElapsed += Time.deltaTime;
        
      int num = Next(0, 101);
        float variable = num;
      
        if(variable < 50 && Time.time > LastMove + 1.2f){
            float direction2 = -30f;
            Vector3 movement = new Vector3(direction2 * movementSpeed * Time.deltaTime, 0f, 0f);
            transform.Translate(movement);
            LastMove = Time.time;
        }
        else if(variable >= 50 && Time.time > LastMove + 1.2f)
        {
            float direction2 = 30f;

            Vector3 movement = new Vector3(direction2 * movementSpeed * Time.deltaTime, 0f, 0f);

            transform.Translate(movement);
            LastMove = Time.time;
        }
    
        
        Vector3 direction = Alex.transform.position - transform.position;
        if(direction.x >= 0.0f) transform.localScale = new Vector3(6.5f,6.5f,1.0f);
        else transform.localScale = new Vector3(-6.5f,6.5f,1.0f);
        float distance = Mathf.Abs(Alex.transform.position.x - transform.position.x);
        if (distance < 4.0f && Time.time > LastShoot + 1.5f){
            Shoot();
            LastShoot = Time.time;
        }
        if(Alex == null) return;
    }

    private void Shoot(){
        Vector3 direction;
        if(transform.localScale.x > 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject bullet = Instantiate(BulletPrefabEnemy, transform.position + direction * 0.5f, Quaternion.identity);
        bullet.GetComponent<Bullet_Grunt_Script>().setDirection(direction);
    }

     public void Hit(){
        sliderVidas = sliderVidas - 20;
        if (sliderVidas == 0){
             
            //Alex.SubtractEnemies();
            OnEnemyEliminated?.Invoke();
            //gameObject.GetComponent<Alex_movement>().SubtractEnemies();
            Destroy(gameObject);
           
        } 
    }


    public int Next(int min, int max)
    {
        semilla = (a * semilla + c) % m;
        int num2 =  (int)((max - min) * ((double)semilla / m))+min;
        semilla = semilla * Time.time;
        return num2;
    }

}
