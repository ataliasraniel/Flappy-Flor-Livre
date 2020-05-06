using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Store_Manager : MonoBehaviour
{

    //TODA PARTE DA UI FICA AQUI
    [Header("Painel de Compra")]
    public GameObject Loja;
    public GameObject buttonBack;
    public GameObject btnLoja;
    public TextMeshProUGUI Moedas;
    [Header("Painel seleção Skin")]
    public GameObject PainelSelecao;
    public TextMeshProUGUI nomeSelecao;    
    public Image IconeSelecao;
    public GameObject buttonCancelarSelecao;
    public GameObject buttonConfirmarSelecao;
    [Header("Painel de confirmar")]
    public GameObject PainelCompra;  
    public TextMeshProUGUI nomeCompra;
    public TextMeshProUGUI precoCompra;    
    public Image IconeCompra;
    public GameObject buttonCancelCompra;
    public GameObject buttonConfirmCompra;
    [Header("Lógica dos itens")]     
    public int[] index;
    public GameObject[] itens;
    public int preco;
    public bool compro;
    public Item_Store itemStore;
    private Moedas_controller _moedasControlle;
    private MainMenu_AudioController _audioController;
    

    private void Awake()
    {
         
        _audioController = FindObjectOfType<MainMenu_AudioController>().GetComponent<MainMenu_AudioController>();
        _moedasControlle = GameObject.Find("Moedas_controller").GetComponent<Moedas_controller>();
        MinhasMoedas();
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.R))
    //     {
    //         SceneManager.LoadScene("Flappy Flor_main_menu");
    //     }
    // }
    public void PegaInfoSelecao()
    {
        nomeSelecao = GameObject.Find("Item_name_selecao_painel").GetComponent<TextMeshProUGUI>();
        IconeSelecao = GameObject.Find("Item_icon_selecao").GetComponent<Image>();
        _audioController.SomInteragir();
    }
    public void PegaInfoPainelCompra()
    {
        nomeCompra = GameObject.Find("Item_name_compra_painel").GetComponent<TextMeshProUGUI>();
        IconeCompra = GameObject.Find("Item_icon").GetComponent<Image>();
        precoCompra = GameObject.Find("Item_price").GetComponent<TextMeshProUGUI>();
         _audioController.SomInteragir();
    }

    public void MinhasMoedas()
    {
        Moedas.text = _moedasControlle.moedas.ToString();

    }
    
    public void Voltar()
    {
        Loja.SetActive(false);
        btnLoja.SetActive(true);
        _audioController.Cancela();
    }


    
    #region painel de seleção
    //TODA A LÓGICA DO PAINEL DE SELEÇÃO
   
    #endregion
}
