using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CI.QuickSave;

public class Item_Store : MonoBehaviour
{
    [Header("Informações dos Itens")]
    public string nome;
    public int preco;
    public Image ItemIcone;   
    public int IndexCompra;   
    public Store_Manager storeManager;
    [Header("Lógica da Compra")]
    public bool comprou;
    public GameObject verde;
    public GameObject amarelo;
    private Moedas_controller _moedas_controller;
    public TextMeshProUGUI contadorMoedas;

    public GameObject painelCompra;
    public GameObject painelCompraClone;
    public GameObject painelSelecao;
    public  GameObject painelSelecaoClone;
    private Button btn;
    public Button btnCompra;
    private Button btnCancela;    
    public Transform CanvasPai;
    private TextMeshProUGUI vertex;
    [Header("Lógic Skins")]
    public int SkinIndex;
    private Button btnConfirmaSkin;
    private Game_manager _gameManager;
    private MainMenu_AudioController _audioController;
    
    void Start()
    {
        _audioController = FindObjectOfType<MainMenu_AudioController>().GetComponent<MainMenu_AudioController>();
        _gameManager = GameObject.Find("Game_manager").GetComponent<Game_manager>();
        CarregaComprou();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(AbrirPainel);
        storeManager = GameObject.Find("Store_controller").GetComponent<Store_Manager>();
        _moedas_controller = GameObject.Find("Moedas_controller").GetComponent<Moedas_controller>();
        ChecarStatus();
        
       
    }
    
  
    #region RELAÇÃO DA UI COM A LÓGICA ETC
    //TODA LÓGICA PARA ABRIR OS PAINÉIS ESTÃO AQUI
    private void AbrirPainel()
    {
        if (comprou == true)
        {
            painelSelecaoClone = Instantiate(painelSelecao, CanvasPai);                       
            btnCancela = GameObject.Find("Button_cancelar").GetComponent<Button>();
            btnCancela.onClick.AddListener(Cancelar);
            vertex = GameObject.Find("Item_name_selecao_painel").GetComponent<TextMeshProUGUI>();
            vertex.gameObject.AddComponent<TMPro.Examples.VertexShakeB>();
            btnConfirmaSkin = GameObject.Find("Button_selecionar_skin").GetComponent<Button>();
            btnConfirmaSkin.onClick.AddListener(SelecionaSkin);
        }
        else if (comprou == false)
        {
            painelCompraClone = Instantiate(painelCompra, CanvasPai);                     
            btnCancela = GameObject.Find("Button_cancelar").GetComponent<Button>();
            btnCancela.onClick.AddListener(Cancelar);
            btnCompra = GameObject.Find("Button_comprar").GetComponent<Button>();
            btnCompra.onClick.AddListener(Comprar);
            vertex = GameObject.Find("Item_name_compra_painel").GetComponent<TextMeshProUGUI>();
            vertex.gameObject.AddComponent<TMPro.Examples.VertexShakeB>();
        }
        PegaInfos();
        
    }
    private void SalvarComprou(){
        QuickSaveWriter.Create("dadosLoja")
        .Write("comprou", comprou)
        .Commit();
    }
    private void CarregaComprou(){
       
        comprou = _gameManager.itensComprados[IndexCompra];
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)){
            CarregaComprou();
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            SalvarComprou();
        }
    }
    private void Cancelar()
    {
        if(comprou == true)
        {
            Destroy(painelSelecaoClone);
            
        }
        else if(comprou == false)
        {
            Destroy(painelCompraClone);
        }
        _audioController.Cancela();
    }    
    public void ChecarStatus()
    {
        if (comprou == true)
        {

            verde.SetActive(true);
            amarelo.SetActive(false);
        }
        else if (comprou == false)
        {
            amarelo.SetActive(true);
            verde.SetActive(false);
        }
        storeManager.MinhasMoedas();
        
    }

    void PegaInfos()
    {
        if (comprou == true)
        {
            storeManager.PegaInfoSelecao();
            storeManager.nomeSelecao.text = nome;
            storeManager.IconeSelecao.sprite = ItemIcone.sprite;
        }
        else if (comprou == false)
        {
            storeManager.PegaInfoPainelCompra();
            storeManager.nomeCompra.text = nome;            
            storeManager.precoCompra.text = preco.ToString();
            storeManager.IconeCompra.sprite = ItemIcone.sprite;

        }

    }


    #endregion
    #region LÓGICA DA COMPRA
    //AQUI ESTARÁ TUDO RELACIONADO À COMPRA
    public void Comprar()
    {
        if (_moedas_controller.moedas >= preco)
        {
            _moedas_controller.GastaMoedas(preco);
            comprou = true;
            Destroy(painelCompraClone);
            _gameManager.itensComprados[IndexCompra] = true;
            ChecarStatus();            
            SalvarComprou();
            _gameManager.SalvarItensComprados();
            _audioController.Comprou();
        }
    }
    public void SelecionaSkin()
    {
        _gameManager.index = SkinIndex;
        _gameManager.SpawnaSkinsMenu();
        _gameManager.SalvaIndex();
        Destroy(painelSelecaoClone);
        _audioController.Skin();
    }
    #endregion
}
