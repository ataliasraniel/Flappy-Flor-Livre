using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;
using UnityEngine.SceneManagement;



public class Game_manager : MonoBehaviour
{
    public static Game_manager instance;

    [Header("Loja e Moedas")]
    private Moedas_controller _moedasController;
    public bool[] itensComprados;    
    private Item_Store _itemStore;
    private int moedas;
    [Header("Lógica do Jogo")]
    public GameObject[] Jogador;
    [Header("Skins que aparece no menu")]
    public GameObject[] SkinsMenu;
    private GameObject SkinClone;
    private Rigidbody2D cloneRb;
    private Skin_menu_manager _skinMenuManager;
    private Transform LocalInstanciar;
    public int index = 0;
     
    

    private void Awake()
    {
        QuickSaveRoot.Delete("Dados");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        //REFERÊNCIA AOS SCRIPTS
        _moedasController = GameObject.Find("Moedas_controller").GetComponent<Moedas_controller>();
        moedas = _moedasController.moedas;
        CarregarItensComprados();
        CarregaIndex();
        
    }
    private void Start()
    {
       
        LocalInstanciar = GameObject.Find("item_local_skin").GetComponent<Transform>();
        SkinClone = Instantiate(SkinsMenu[index], LocalInstanciar);
        TiraAtributos();
        
    }
    
    public void PegarReferenciaItensLoja()
    {
        _itemStore = GameObject.FindGameObjectWithTag("Item").GetComponent<Item_Store>();
    }
    public void SpawnaSkinsMenu()
    {
        if(SkinClone !=null)
       {
        Destroy(SkinClone);
       }
        LocalInstanciar = GameObject.Find("item_local_skin").GetComponent<Transform>();
        SkinClone = Instantiate(SkinsMenu[index], LocalInstanciar);
        TiraAtributos();
        
        
    }
    private void TiraAtributos(){
        cloneRb = SkinClone.GetComponent<Rigidbody2D>();
        Bird_Control _birdControll = SkinClone.GetComponent<Bird_Control>();
        Destroy(_birdControll);
        Destroy(cloneRb);
       
    }
    private void CarregarCompras(){
       
        
        foreach (bool item in itensComprados)
        {
            itensComprados[index] = true;
        }

    }
    //SALVA E CARREGA SKINS
    public void SalvaIndex()
    {
        QuickSaveWriter.Create("Dados")
        .Write("index", index)
        .Commit();
        
    }
    public void CarregaIndex()
    {
         QuickSaveReader.Create("Dados")
         .Read<int>("index", (r) =>{index = r; });
        
    }
    public void SalvarItensComprados(){
        QuickSaveWriter.Create("Dados")
        .Write("compras", itensComprados)
        .Commit();
    }
    private void CarregarItensComprados(){
        QuickSaveReader.Create("Dados")
        .Read<bool[]>("compras", (r) =>{itensComprados = r; });
    }
    #region Gameplay
    //TUDO RELACIONADO AO GAMEPLAY

    //SPAWNA A SKIN DO JOGADOR SELECIONADO NA CENA DE JOGO
    public void SpawnarJogador()
    {
    
      if(SceneManager.GetActiveScene().name == "Flappy Flor")
        {
            Debug.Log(SceneManager.GetActiveScene());
        }
    }

   #endregion
   
}