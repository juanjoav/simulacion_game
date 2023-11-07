using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Menu_Game_Over : MonoBehaviour
{
    [SerializeField] private GameObject PanelGameOver;
    private Alex_movement player;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Alex").GetComponent<Alex_movement>();
        player.MuerteJugador += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e){
        PanelGameOver.SetActive(true);
    }

    public void Reiniciar(){

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        }
        public void Exit(){
            Debug.Log("Salir del juego");
            Application.Quit();
        }    


}
