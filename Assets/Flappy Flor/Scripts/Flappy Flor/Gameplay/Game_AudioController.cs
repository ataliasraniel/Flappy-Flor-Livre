using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_AudioController : MonoBehaviour
{
    public AudioSource AS;
    public AudioSource ASMusica;

    public AudioClip somMoeda;
    public AudioClip musicaUm;
    public AudioClip musicaDois;
    public AudioClip somExplosao;
    private int aleatorio;
    
    private void Start() {
        aleatorio = Random.Range(0, 4);
        ASMusica.playOnAwake = true;   
        musica();
    }
    public void MoedaPickUp(){
        AS.PlayOneShot(somMoeda);
    }
    private void musica(){
        if(aleatorio >=2){
            ASMusica.PlayOneShot(musicaDois);
        }
        else if(aleatorio <=1){
            ASMusica.PlayOneShot(musicaUm);
        }
    }
    public void Explosao(){
        AS.PlayOneShot(somExplosao);
    }
}
