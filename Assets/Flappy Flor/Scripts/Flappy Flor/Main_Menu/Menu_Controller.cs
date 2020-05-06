using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Menu_Controller : MonoBehaviour
{
    //SINGLETON DO CONTROLE
    public static Menu_Controller instance;
    
    public Transform ButtonPos;
    public float time;
    private Moedas_controller _moedasController;
    [Space]
    [Header("Itens de UI")]
    public GameObject[] Menu_principal;
    public GameObject Menu_option;
    public GameObject Loja;
    public GameObject btnLoja;
    private Moedas_controller _moedasControll;
    private Game_manager _gameManager;

    

   

   
    private void Start()
    {
        _gameManager = GameObject.Find("Game_manager").GetComponent<Game_manager>();
        _moedasControll = GameObject.Find("Moedas_controller").GetComponent<Moedas_controller>();   
    }

    #region Menu Principal
    //REFERÊNCIAS DO MENU PRINCIPAL
    public void AbrirLoja()
    {
        MainMenu_AudioController audio = FindObjectOfType<MainMenu_AudioController>().GetComponent<MainMenu_AudioController>();
        audio.SomInteragir();
        Store_Manager storeMan = GameObject.Find("Store_controller").GetComponent<Store_Manager>();
        btnLoja.SetActive(false);
        Loja.SetActive(true);
        storeMan.MinhasMoedas();
        _gameManager.PegarReferenciaItensLoja();
        
    }
    public void Play(){
        
        MainMenu_AudioController audio = FindObjectOfType<MainMenu_AudioController>().GetComponent<MainMenu_AudioController>();
        audio.SomInteragir();
        SceneManager.LoadScene("Flappy Flor");
        _gameManager.SpawnarJogador();
        

    }    
    public void Open_Option_Menu(){
        
        Menu_option.SetActive(true);
        
        
    }
    public void Close_Option_menu(){

        Menu_option.SetActive(false);
        foreach (GameObject item2 in Menu_principal)
        {
            item2.SetActive(true);
        
        }

    }
    public void QuitApp(){

        Application.Quit();
    }
#endregion
}








