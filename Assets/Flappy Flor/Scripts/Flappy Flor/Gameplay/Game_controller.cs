using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_controller : MonoBehaviour
{
    public Game_manager _gameManager;

    [Header("Jogador")]
    public GameObject[] jogador;
    public Transform posicaoSpawn;
    public int index;
    private void Start()
    {
        
        // if(_gameManager == null){
        //     index = 4;
        //     CriarJogador();
        // }
        _gameManager = GameObject.Find("Game_manager").GetComponent<Game_manager>();
        index = _gameManager.index;
        CriarJogador();
    }
    private void CriarJogador()
    {
        Instantiate(jogador[index], posicaoSpawn.transform.position, Quaternion.identity);
    }
    public void abrirMenu(){
        StartCoroutine(AbrirMenuMorte());
    }
    IEnumerator AbrirMenuMorte(){
        
        yield return new WaitForSeconds(0.75f);
        Game_UI_controller ui = FindObjectOfType<Game_UI_controller>().GetComponent<Game_UI_controller>();
        ui.AbrirMenuPause();
    }
}
