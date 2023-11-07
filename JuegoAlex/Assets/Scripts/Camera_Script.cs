using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public GameObject Alex;

    // Update is called once per frame
    void Update()
    {
        if(Alex != null){
        Vector3 position = transform.position;
        position.x = Alex.transform.position.x;
        transform.position = position;
        }
    }
}
