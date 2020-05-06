using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game_UI_controller : MonoBehaviour
{   
    
    [Header("Contadores")]
    public TextMeshProUGUI contadorMoedas;
    public TextMeshProUGUI contadorMoedasMenu;

    public GameObject pauseMenu;
    public MainMenu_AudioController audioController;

    private void Start()
    {
        atualizaContador();
    }
   
    #region UI DO GAMEPLAY
    public void atualizaContador()
    {
        contadorMoedas.text = FindObjectOfType<Moedas_controller>().moedas.ToString();
    }
    #endregion
    #region ABRE E FECHA MENUS
    public void AbrirMenuPause()
    {
        audioController.SomInteragir();
        Obstacle_manager obsManager = FindObjectOfType<Obstacle_manager>().GetComponent<Obstacle_manager>();
        obsManager.StopAllCoroutines();
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        contadorMoedasMenu.text = FindObjectOfType<Moedas_controller>().moedas.ToString();
    }
    public void FecharMenuPause()
    {   
        audioController.Cancela();
        Obstacle_manager obsManager = FindObjectOfType<Obstacle_manager>().GetComponent<Obstacle_manager>();
        obsManager.StartCoroutine(obsManager.Spawn());
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Recarregar()
    {
        audioController.SomInteragir();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void IrMainMenu()
    {
        audioController.SomInteragir();
        Obstacle_manager obsManager = FindObjectOfType<Obstacle_manager>().GetComponent<Obstacle_manager>();
        obsManager.StopAllCoroutines();
        SceneManager.LoadScene(0);
        if(Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }
        
    }
    #endregion
}
