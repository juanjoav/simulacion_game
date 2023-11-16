using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscenas_Dos : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animationFinal;
    [SerializeField] private float tiempoEspera = 10f; // Cambia este valor al tiempo que desees esperar en segundos

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

        SceneManager.LoadScene(2);
    }
}
