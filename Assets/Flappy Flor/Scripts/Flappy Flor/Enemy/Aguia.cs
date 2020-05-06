using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Aguia : MonoBehaviour
{
    public float velocidade;
    private int vida;
    private Inimigo inimigo;

    [Header("Inteligência Artificial")]
    private RaycastHit2D hitInfo;
    public Transform pontoInicial;
    public Transform pontoFinal;
    public float distancia;
    private RaycastHit2D hit;
    
    
    public Transform sprite;
    public float tempoAtaque;
    private bool perseguir;
    private Vector3 ultimaPosicao;
    private Transform minhaPosicao;
    private bool estaMovendo;

    void Start()
    {
       
        minhaPosicao = transform;
        ultimaPosicao = minhaPosicao.position;
        inimigo = GetComponent<Inimigo>();
        vida = inimigo.HP;
        Destroy(gameObject, 12);
    }
    void Update()
    {
        
        if(minhaPosicao.position != ultimaPosicao){
            estaMovendo = true;
        }
        else{
            estaMovendo = false;
        }
        Movimentacao();
        Detectar();
        if(perseguir == true){
           StartCoroutine(Ataque1());
        }
        else if(perseguir == false){
            
            StopAllCoroutines();
            estadoNormal();
        }
    }
    private void Movimentacao()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        
    }
    #region INTELIGÊNCIA ARTIFICIAL
    /// <summary>
    /// Construir um colisor que possa detectar se o jogador está no raio de alcance
    /// se estiver, executar um ataque de perseguição
    /// </summary>
    /// 
    //SISTEMA DE DETECÇAO DO JOGADOR
   
    private void Detectar()
    {
             
        RaycastHit2D hit = Physics2D.Raycast(pontoInicial.position, Vector3.left, distancia);
        if(hit){
                        
            if(hit.collider.tag == "player"){
               pontoFinal = hit.transform.GetComponent<Transform>();
                perseguir = true;
            }
        }
        else{
            
            perseguir = false;

        }
        Debug.DrawRay(pontoInicial.position, Vector3.left * distancia, Color.red);
        
    }
    IEnumerator Ataque1(){
        
        if(perseguir == true){
        Mirar();
        yield return new WaitForSeconds(tempoAtaque);        
        Perseguir();
        }
    }
    private void estadoNormal(){        
        sprite.transform.DOScale(new Vector3(0.18f, 0.18f, 0.18f), 0.1f);
        velocidade = 2;
        StopCoroutine(Ataque1());
    }
    private void Mirar(){
        velocidade = 0;
        sprite.DOScale(new Vector3(0.1f, sprite.transform.localScale.y, 0), 0.7f);
        
        
    }
    private void Perseguir(){   
    
       transform.DOLocalMove(pontoFinal.transform.position, 1);
       sprite.DOScale(new Vector3(0.26f, 0.11f, 0), 0.1f);
    }    
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.tag == "player")
        // {
        //     inimigo.levarDano(5);
        //     vida = inimigo.HP;
        //     if(vida <= 0)
        //     {
        //         inimigo.morrer();
        //     }
        // }
    }
}
