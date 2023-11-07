using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrToronjo_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Alex;
    public GameObject SpeedBullet;
    public GameObject WaterBullet;
    public GameObject BeerBullet;
    public float speed;
    private float distance;
    private float lastShoot;
    private int lastState;

    private float semilla;
    private const long a = 1103515245;
    private const long c = 12345;
    private const long m = 2147483648;

    void Start()
    {
        semilla = Random.Range(0f, 10000f);
        lastState = 1; //Water
    }

    // Update is called once per frame
    void Update()
    {
        //Shoot();
        distance = Vector2.Distance(transform.position, Alex.transform.position);
        Vector3 direction = Alex.transform.position - transform.position;
        if (distance < 7.0f) {
            transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(Alex.transform.position.x, transform.position.y), speed * Time.deltaTime);
            if (transform.position.x == Alex.transform.position.x && Time.time > lastShoot+1.0F) {
                lastShoot = Time.time;
                Under(direction);
            }
        }
        if (direction.x >= 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void Shoot() {
        Debug.Log(distance);
    }

    float GenerateRandomNumber()
    {
        semilla = (a * semilla + c) % m;
        float num2 = ((1 - 0) * (semilla / m)) + 0;
        Debug.Log(num2);
        return num2;
    }

    void Under(Vector3 direction) {
        float randomNumber = GenerateRandomNumber();
        Debug.Log(lastState);
        if (lastState == 1){//Water
            if(randomNumber < 0.2f){
                lastState = 1;//Water
                GameObject bullet = Instantiate(WaterBullet, new Vector3(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
                bullet.GetComponent<WaterBullet>().SetDirection(direction);
            }else if(randomNumber < 0.6f){
                lastState = 2;//Beer
                GameObject bullet = Instantiate(BeerBullet, new Vector3(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
                bullet.GetComponent<BeerBullet>().SetDirection(direction);
            }else{
                lastState = 3;//Speed
                GameObject bullet = Instantiate(SpeedBullet, new Vector3(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
                bullet.GetComponent<SpeedBullet>().SetDirection(direction);
            }
        } else if(lastState == 2){//Beer
            if(randomNumber < 0.4f){
                lastState = 2;//Beer
                GameObject bullet = Instantiate(BeerBullet, new Vector3(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
                bullet.GetComponent<BeerBullet>().SetDirection(direction);
            }else if(randomNumber < 0.6f){
                lastState = 1;//Water
                GameObject bullet = Instantiate(WaterBullet, new Vector3(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
                bullet.GetComponent<WaterBullet>().SetDirection(direction);
            }else{
                lastState = 3;//Speed
                GameObject bullet = Instantiate(SpeedBullet, new Vector3(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
                bullet.GetComponent<SpeedBullet>().SetDirection(direction);
            }
        }else{
            if(randomNumber < 0.4f){
                lastState = 3;//Speed
                GameObject bullet = Instantiate(SpeedBullet, new Vector3(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
                bullet.GetComponent<SpeedBullet>().SetDirection(direction);
            }else if(randomNumber < 0.6f){
                lastState = 1;//Water
                GameObject bullet = Instantiate(WaterBullet, new Vector3(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
                bullet.GetComponent<WaterBullet>().SetDirection(direction);
            }else{
                lastState = 2;//Beer
                GameObject bullet = Instantiate(BeerBullet, new Vector3(transform.position.x, transform.position.y - 0.6f), Quaternion.identity);
                bullet.GetComponent<BeerBullet>().SetDirection(direction);
            }
        }
    }
}
