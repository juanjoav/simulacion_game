// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.Windows;



// public class TransicionEscenas : MonoBehaviour
// {

//     private Animator animator;
//     [SerializeField] private AnimationClip animationFinal;
//     // Start is called before the first frame update
//     void Start()
//     {
//         animator = GetComponent<Animator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
//         {
//             //Cambio de escena
//             StartCoroutine(CambiarEscena());
//         }
//     }

//     IEnumerator CambiarEscena(){

//         animator.SetTrigger("Iniciar");
//         yield return new WaitForSeconds(animationFinal.length);

//         SceneManager.LoadScene(1);

//     }
// }

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscenas : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animationFinal;
    [SerializeField] private float tiempoEspera = 5f; // Cambia este valor al tiempo que desees esperar en segundos

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CambiarEscenaDespuesDeTiempo());
    }

    IEnumerator CambiarEscenaDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoEspera);
        StartCoroutine(CambiarEscena());
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animationFinal.length);

        SceneManager.LoadScene(1);
    }
}

// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class TransicionEscenas : MonoBehaviour
// {
//     private Animator animator;
//     [SerializeField] private AnimationClip animationFinal;
//     [SerializeField] private float tiempoEspera = 10f;

//     void Start()
//     {
//         animator = GetComponent<Animator>();
//         StartCoroutine(CambiarEscenasDespuesDeTiempo());
//     }

//     IEnumerator CambiarEscenasDespuesDeTiempo()
//     {
//         yield return new WaitForSeconds(tiempoEspera);
//         StartCoroutine(CambiarEscena(1)); // Cambia a la primera escena después del tiempo especificado
//         yield return new WaitForSeconds(animationFinal.length); // Espera a que termine la animación

//         StartCoroutine(CambiarEscena(2)); // Cambia a la segunda escena
//         yield return new WaitForSeconds(animationFinal.length); // Espera a que termine la animación

//         StartCoroutine(CambiarEscena(3)); // Cambia a la tercera escena
//     }

//     IEnumerator CambiarEscena(int sceneIndex)
//     {
//         animator.SetTrigger("Iniciar");
//         yield return new WaitForSeconds(animationFinal.length);

//         SceneManager.LoadScene(sceneIndex);
//     }
// }

