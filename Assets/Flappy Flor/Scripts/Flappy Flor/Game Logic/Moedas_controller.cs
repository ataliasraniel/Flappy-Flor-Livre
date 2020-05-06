using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moedas_controller : MonoBehaviour
{
    public static Moedas_controller instance;

    [Header("Lógica das Moedas")]
    public int moedas;
    private void Awake()
    {
        //SINGLETON
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        CarregaMoedas();

    }
    

    public void GanhaMoedas(int quantidade)
    {
        moedas += quantidade;
        AtualizaMoedas();
    }
    public void CarregaMoedas()
    {
        if(PlayerPrefs.HasKey("Moedas") == false)
        {
            moedas = 20;
        }
        moedas = PlayerPrefs.GetInt("Moedas");
        
       
    }
    public void AtualizaMoedas()
    {
        PlayerPrefs.SetInt("Moedas", moedas);
        ControlaMoedas();
    }
    public void GastaMoedas(int preco)
    {
        moedas -= preco;
        ControlaMoedas();
    }
    void ControlaMoedas()
    {
        if(moedas <= 0)
        {
            moedas = 0;
        }
    }
}
